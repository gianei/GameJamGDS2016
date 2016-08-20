using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

	public float projectileSpeed = 1f;

	Vector2 projectileDirection;
	ElementList elementList;
	private Rigidbody2D rigidBody;

	static public void StartNew(GameObject projectilePrefab,Vector3 projectileStartingPoint, Vector2 projectileDirection, ElementList elementList)
	{
		GameObject newProjectile = (GameObject)Instantiate (projectilePrefab, projectileStartingPoint, Quaternion.identity);
		ProjectileController projectileController = newProjectile.GetComponent<ProjectileController> ();
		projectileController.projectileDirection = projectileDirection;
		projectileController.elementList = new ElementList(elementList.getActiveElements());
		projectileController.Initialize ();
		if (projectileController.elementList == null)
			Debug.Log ("FUUUU1");
	}

	void Initialize()
	{
		rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.velocity = projectileDirection * projectileSpeed;
		Debug.Log (projectileDirection.ToString () + "   " + projectileSpeed.ToString ());

		//[TEST]
		if (this.elementList == null)
			Debug.Log ("FUUUU2");
		ElementType colorTest = this.elementList.getFirstActiveElement();

		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		switch (colorTest) 
		{
		case ElementType.A:
			spriteRenderer.color = Color.blue;
			break;

		case ElementType.B:
			spriteRenderer.color = Color.red;
			break;

		case ElementType.C:
			spriteRenderer.color = Color.green;
			break;

		default:
			break;
		}
		
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Debug.Log(elementList.getFirstActiveElement());
            Debug.Log(coll.gameObject.GetComponent<EnemyController>().Type);

            if (coll.gameObject.GetComponent<EnemyController>().Type == elementList.getFirstActiveElement())
                Destroy(coll.gameObject);


        }

    }
}
