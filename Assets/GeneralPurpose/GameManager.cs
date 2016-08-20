using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Singleton = null;
    //Static singleton of GameManager which allows it to be accessed by any other script.


    private Text _playerLifesText;
    private int _playerLifes = 5;

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
    void Start()
    {
        _playerLifesText = GetComponentInChildren<Text>(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyHitBase()
    {
        _playerLifes--;
        _playerLifesText.text = "Lifes: " + _playerLifes;
        
        Debug.Log("Enemy Hit!");
    }
}
