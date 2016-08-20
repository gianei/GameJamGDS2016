using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public GameObject projectilePrefab;
	public Transform projectileSpawnPoint;
	public float shotCooldown = 1f;

	float timeOfLastShot;
	ElementList activeElements;



	// Use this for initialization
	void Start () 
	{
		this.activeElements = new ElementList ();
		this.timeOfLastShot = -1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
		
	void spawnProjectile(Vector2 projectileDirection)
	{
		//If any element is active, there the possibilite of firing a projectile, else not.
		if ( (Time.time - this.timeOfLastShot) >= shotCooldown &&
				this.activeElements.AtLeastOneElementIsActive()) 
		{			

			ProjectileController.StartNew(projectilePrefab, this.projectileSpawnPoint.position, projectileDirection, this.activeElements);
			this.timeOfLastShot = Time.time;
			this.activeElements.ResetElements ();
		}
	}

	/////////////InputManager calling functions//////////////

	public void FireProjectile(Vector3 mousePosition)
	{
		Debug.Log ("CLICK:" + mousePosition);
		Vector2 projectileDirection = new Vector2 (mousePosition.x - projectileSpawnPoint.position.x,
			                              mousePosition.y - projectileSpawnPoint.position.y);
		projectileDirection.Normalize ();

		this.spawnProjectile (projectileDirection);
	}

	public void SwitchElementActivation(ElementType elementTypeToBeSwitched)
	{
		this.activeElements.SwitchElementState (elementTypeToBeSwitched);
	}

}
