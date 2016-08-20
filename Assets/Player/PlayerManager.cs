using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager Singleton = null;
	public Animator playerAnimator;
	public GameObject elementActivationStatePanel;
    public GameObject lifesPanel;
    public GameObject projectilePrefab;
	public Transform projectileSpawnPoint;
	public float shotCooldown = 1f;

	bool canShoot;
	float timeOfLastShot;
	ElementList elements;

    private int _lifes = 0;


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
		this.elements = new ElementList ();
		this.timeOfLastShot = -1;
		this.canShoot = true;

        elementActivationStatePanel.SetActive(false);
        lifesPanel.SetActive(false);

	    this.elements.ResetElements();
        SetLifes();
   

	}
	
	// Update is called once per frame
	void Update () 
	{

	    if ((Time.time - this.timeOfLastShot >= shotCooldown) && canShoot == false)
	    {
	        this.canShoot = true;
	        SoundManager.Singleton.PlayPowerRecharged();
	    }
	    else if (Time.time - this.timeOfLastShot < shotCooldown)
	    {
	        this.canShoot = false;
	    }
	    
	}
		
	void spawnProjectile(Vector2 projectileDirection)
	{
		//If any element is active, there the possibilite of firing a projectile, else not.
		if ( (Time.time - this.timeOfLastShot) >= shotCooldown &&
				this.elements.AtLeastOneElementIsActive()) 
		{			

			playerAnimator.SetTrigger ("attack");
			ProjectileController.StartNew(projectilePrefab, this.projectileSpawnPoint.position, projectileDirection, this.elements);
			this.timeOfLastShot = Time.time;
			this.elements.ResetElements ();

			//[SOUND]
			SoundManager.Singleton.PlayElementFire(this.elements.getFirstActiveElement());
		}
	}

	/////////////InputManager calling functions//////////////

	public void FireProjectile(Vector3 mousePosition)
	{
		//Debug.Log ("CLICK:" + mousePosition);
		Vector2 projectileDirection = new Vector2 (mousePosition.x - projectileSpawnPoint.position.x,
			                              mousePosition.y - projectileSpawnPoint.position.y);
		projectileDirection.Normalize ();

		this.spawnProjectile (projectileDirection);
		updateActivationPanel ();
	}

	public void SwitchElementActivation(ElementType elementTypeToBeSwitched)
	{
		this.elements.SwitchElementState (elementTypeToBeSwitched);
		updateActivationPanel ();
	}

	///////////// Interaction with the Element Activation State sprites //////////////////////

	public void updateActivationPanel()
	{
		SpriteRenderer[] elementActivationRendererList = this.elementActivationStatePanel.GetComponentsInChildren<SpriteRenderer> ();
		Color[] activeElementColors = new Color[3];
		activeElementColors [0] = new Color (8/255F, 40/255F, 48/255F);
		activeElementColors [1] = new Color (8/255F, 40/255F, 48/255F);
		activeElementColors [2] = new Color (8/255F, 40/255F, 48/255F);

		foreach (ElementType activeElement in this.elements.getActiveElements()) 
		{
			switch (activeElement) 
			{
			case ElementType.A:
				activeElementColors [0] = Color.white;
				break;
			case ElementType.B:
				activeElementColors [1] = Color.white;
				break;
			case ElementType.C:
				activeElementColors [2] = Color.white;
				break;
			default:
				break;
			}
		}
		elementActivationRendererList [0].color = activeElementColors [0];
		elementActivationRendererList [2].color = activeElementColors [1];
		elementActivationRendererList [4].color = activeElementColors [2];

	}


    public void LoseALife()
    {
        _lifes--;

        SpriteRenderer[] lifeSprites = lifesPanel.GetComponentsInChildren<SpriteRenderer>();
        if (_lifes == 2)
            lifeSprites[2].enabled = false;
        if (_lifes == 1)
            lifeSprites[1].enabled = false;
        if (_lifes == 0)
            lifeSprites[0].enabled = false;
        if (_lifes < 0)
            GameManager.Singleton.EndGame();


    }

    public void StartGame()
    {
        _lifes = 3;
        SetLifes();

        elementActivationStatePanel.SetActive(true);
        lifesPanel.SetActive(true);
    }

    private void SetLifes()
    {
        SpriteRenderer[] lifeSprites = lifesPanel.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in lifeSprites)
        {
            spriteRenderer.enabled = true;
        }
    }

    public void EndGame()
    {
        elementActivationStatePanel.SetActive(false);
        lifesPanel.SetActive(false);
    }

}
