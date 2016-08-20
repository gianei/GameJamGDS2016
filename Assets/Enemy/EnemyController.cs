using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
    public float Speed = 15f;
    public float _scaleIncrement = 0.005f;

    private Vector2 direction = new Vector2(0, -1);
    private Rigidbody2D Rigidbody;
    private SpriteRenderer SpriteRenderer;

    public ElementType Type { get; private set; }

    private float _scale = 0;
    


    // Use this for initialization
    void Start () {
        Rigidbody = GetComponent<Rigidbody2D>();
        Rigidbody.velocity = direction * Speed;
        
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
        _scale += _scaleIncrement;
        gameObject.transform.localScale = Vector3.one * _scale;
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
