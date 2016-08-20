using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum State
    {
        Menu,
        Game
    }

    public static GameManager Singleton = null;
    //Static singleton of GameManager which allows it to be accessed by any other script.


    private Text _playerScoresText;
    private int _playerScore = 0;
    private State gameState = State.Menu;
    private Transform _menuTransform;

    public State GameState
    {
        get { return gameState; }
    }

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
        _playerScoresText = GetComponentInChildren<Text>(true);
        _playerScoresText.text = "";

        _menuTransform = gameObject.transform.FindChild("MainMenu");

		//[Sound]
		SoundManager.Singleton.PlayBackgroundMusic();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerHitEnemyCorrect()
    {
        _playerScore++;
        setScoreText();
    }

    private void setScoreText()
    {
        _playerScoresText.text = "Score: " + _playerScore;
    }

    public void StartGame()
    {
        _playerScore = 0;
        _playerScoresText.text = "Score: " + _playerScore;
        gameState = State.Game;

        _menuTransform.gameObject.SetActive(false);
        EnemySpawner.Singleton.StartSpawning();
        PlayerManager.Singleton.StartGame();
    }

    public void EndGame()
    {
        gameState = State.Menu;
        _playerScoresText.text = "";
        _menuTransform.gameObject.SetActive(true);
        EnemySpawner.Singleton.StopSpawing();
        EnemySpawner.Singleton.RemoveAllSpawned();
        PlayerManager.Singleton.EndGame();
    }
}
