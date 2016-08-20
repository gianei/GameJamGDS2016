using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
    public float InitialSpeed = 0.001f;
    public float SpeedChange = 2;
    public float ScaleChange = 0.004f;

    private Vector2 direction = new Vector2(0, -1);
    private Rigidbody2D _rigidbody;
    private SpriteRenderer SpriteRenderer;

    public ElementType Type { get; private set; }

    private float _scale = 0;
    


    // Use this for initialization
    void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = direction * InitialSpeed;
        
        gameObject.transform.localScale = Vector3.zero;

        SpriteRenderer = GetComponent<SpriteRenderer>();
        int color = Random.Range(0, 3);
        switch (color)
        {
            case 0:
                SpriteRenderer.color = Color.blue;
                Type = ElementType.A;
                break;
            case 1:
                SpriteRenderer.color = Color.red;
                Type = ElementType.B;
                break;
            case 2:
                SpriteRenderer.color = Color.green;
                Type = ElementType.C;
                break;
        }

    }
	
	// Update is called once per frame
	void Update () {
        
	
	}

    void FixedUpdate()
    {
        _scale += ScaleChange;
        gameObject.transform.localScale = Vector3.one * _scale;

        _rigidbody.AddForce(direction * SpeedChange);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Base")
        {
            Destroy(gameObject);
            GameManager.Singleton.EnemyHitBase();
        }

    }
}
