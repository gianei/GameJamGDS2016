using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {


	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("ElementA"))
        {
            Debug.Log("ElementA");
			PlayerManager.Singleton.SwitchElementActivation (ElementType.A);
        }
        else if (Input.GetButtonDown("ElementB"))
        {
			Debug.Log("ElementB");
            PlayerManager.Singleton.SwitchElementActivation (ElementType.B);
        }
		else if (Input.GetButtonDown("ElementC"))
        {
			Debug.Log("ElementC");
            PlayerManager.Singleton.SwitchElementActivation (ElementType.C);
		}
		else if (Input.GetButtonDown("Fire"))
		{
			Debug.Log("Fire");
            PlayerManager.Singleton.FireProjectile (Camera.main.ScreenToWorldPoint (Input.mousePosition));	
		}
    }
}
