using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public GameObject projectileSpawnPoint;
	bool elementAisActive;
	bool elementBisActive;
	bool elementCisActive;

	// Use this for initialization
	void Start () {
		this.ResetElementActivation ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ResetElementActivation()
	{
		this.elementAisActive = false;
		this.elementBisActive = false;
		this.elementCisActive = false;
	}



	/////////////InputManager calling functions//////////////

	public void FireProjectile(Vector3 mousePosition)
	{
		Vector3 projectileDirection = new Vector3 (mousePosition.x - projectileSpawnPoint.transform.position.x,
			                              mousePosition.y - projectileSpawnPoint.transform.position.y,
			                              mousePosition.z - projectileSpawnPoint.transform.position.z);
		//TODO instantiate projectile (MUST HAVE TYPE ON CONSTRUCTOR);

		Debug.DrawLine (projectileSpawnPoint.transform.position, mousePosition);
	}

}
