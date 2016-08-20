using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {
	
	public GameObject trail;
    public float InitialSpeed = 4f;
    public float SpeedChange = 2;
    public float ScaleChange = 0.004f;


    Vector2 projectileDirection;
	ElementList elementList;
	private Rigidbody2D _rigidBody;

    private float _scale = 0.7f;

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
		_rigidBody = GetComponent<Rigidbody2D>();
		_rigidBody.velocity = projectileDirection * InitialSpeed;

		//[TEST]
		if (this.elementList == null)
			Debug.Log ("FUUUU2");
		ElementType colorTest = this.elementList.getFirstActiveElement();

		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		switch (colorTest) 
		{
		case ElementType.A:
			spriteRenderer.color = new Color(10/255f, 191/255f, 227/255f);
			break;

		case ElementType.B:
			spriteRenderer.color =  new Color(240/255f, 144/255f, 0/255f);
			break;

		case ElementType.C:
			spriteRenderer.color =  new Color(48/255f, 233/255f, 48/255f);
			break;

		default:
			break;
		}
			

		Vector2 trailPosition = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y-2f);
		GameObject trailInstantiation = (GameObject) Instantiate (trail, gameObject.transform.position, Quaternion.FromToRotation (new Vector2 (1f, 0f), this.projectileDirection));
		trailInstantiation.transform.parent = gameObject.transform;
		
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        _scale -= ScaleChange;

        gameObject.transform.localScale = Vector3.one * _scale;
        _rigidBody.AddForce(-_rigidBody.velocity.normalized * SpeedChange);

        if (_scale < 0)
            DestroyMe();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            DestroyMe();
            Debug.Log(elementList.getFirstActiveElement());
            Debug.Log(coll.gameObject.GetComponent<EnemyController>().Type);

            if (coll.gameObject.GetComponent<EnemyController>().Type == elementList.getFirstActiveElement())
            {
                Destroy(coll.gameObject);
                GameManager.Singleton.PlayerHitEnemyCorrect();
				//[Sound]
				SoundManager.Singleton.PlayElementExplosion(elementList.getFirstActiveElement());
            }
          

        }

    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}
