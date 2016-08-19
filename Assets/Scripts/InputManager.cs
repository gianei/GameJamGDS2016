using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {


	public PlayerManager playerManager;

	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("ElementA"))
        {
            Debug.Log("ElementA");
        }
        else if (Input.GetButtonDown("ElementB"))
        {
            Debug.Log("ElementB");
        }
		else if (Input.GetButtonDown("ElementC"))
        {
            Debug.Log("ElementC");
		}
		else if (Input.GetButtonDown("Fire"))
		{
			Debug.Log("Fire");
			Debug.Log(Input.mousePosition);
			playerManager.FireProjectile (Input.mousePosition);	
		}
    }
}
