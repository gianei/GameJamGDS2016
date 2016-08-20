using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{


   

    public void MenuStart()
    {
        GameManager.Singleton.StartGame();
    }

    public void MenuCredits()
    {
        Debug.Log("Credit");
    }
}
