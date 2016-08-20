using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

	public float projectileSpeed = 1f;

	Vector2 projectileDirection;
	ElementList activeElementList;
	private Rigidbody2D rigidBody;

	static public void StartNew(GameObject projectilePrefab,Vector3 projectileStartingPoint, Vector2 projectileDirection, ElementList activeElementList)
	{
		GameObject newProjectile = (GameObject)Instantiate (projectilePrefab, projectileStartingPoint, Quaternion.identity);
		ProjectileController projectileController = newProjectile.GetComponent<ProjectileController> ();
		projectileController.projectileDirection = projectileDirection;
		projectileController.activeElementList = activeElementList;
		projectileController.Initialize ();
		if (projectileController.activeElementList == null)
			Debug.Log ("FUUUU1");
	}

	void Initialize()
	{
		rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.velocity = projectileDirection * 1f;
		Debug.Log (projectileDirection.ToString () + "   " + projectileSpeed.ToString ());

		//[TEST]
		if (this.activeElementList == null)
			Debug.Log ("FUUUU2");
		ElementType colorTest = this.activeElementList.getFirstActiveElement();
		if (colorTest != null) 
		{
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
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
