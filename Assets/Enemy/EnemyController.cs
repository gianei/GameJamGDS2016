using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
    public float Speed = 15f;

    private Vector2 direction = new Vector2(0, -1);
    private Rigidbody2D Rigidbody;
    private SpriteRenderer SpriteRenderer;

    private ElementType _type;


    // Use this for initialization
    void Start () {
        Rigidbody = GetComponent<Rigidbody2D>();
        Rigidbody.velocity = direction * Speed;

        SpriteRenderer = GetComponent<SpriteRenderer>();
        int color = Random.Range(0, 3);
        switch (color)
        {
            case 0:
                SpriteRenderer.color = Color.blue;
                _type = ElementType.A;
                break;
            case 1:
                SpriteRenderer.color = Color.red;
                _type = ElementType.B;
                break;
            case 2:
                SpriteRenderer.color = Color.green;
                _type = ElementType.C;
                break;
        }

    }
	
	// Update is called once per frame
	void Update () {
	
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
