using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {


	public PlayerManager playerManager;

	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("ElementA"))
        {
            Debug.Log("ElementA");
			playerManager.SwitchElementActivation (ElementType.A);
        }
        else if (Input.GetButtonDown("ElementB"))
        {
			Debug.Log("ElementB");
			playerManager.SwitchElementActivation (ElementType.B);
        }
		else if (Input.GetButtonDown("ElementC"))
        {
			Debug.Log("ElementC");
			playerManager.SwitchElementActivation (ElementType.C);
		}
		else if (Input.GetButtonDown("Fire"))
		{
			Debug.Log("Fire");
			playerManager.FireProjectile (Camera.main.ScreenToWorldPoint (Input.mousePosition));	
		}
    }
}
