using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {


    // The player prefab that will be instantiated
    public GameObject EnemyPrefab;

    public static EnemySpawner Singleton = null;

    private float _countTime = 0;

    Transform leftmost;
    Transform rightmost;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if singleton already exists
        if (Singleton == null)
        {
            Singleton = this;
        }

        //If singleton already exists and it's not this:
        else if (Singleton != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one singleton of a GameManager.
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        leftmost = transform.FindChild("Leftmost");
        rightmost = transform.FindChild("Rightmost");
    }
	
	// Update is called once per frame
	void Update () {
        _countTime -= Time.deltaTime;
        if (_countTime < 0)
        {
            SpawnEnemy();
            _countTime = 3;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(leftmost.position.x, rightmost.position.x), transform.position.y, 0);

        Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
    }
}
