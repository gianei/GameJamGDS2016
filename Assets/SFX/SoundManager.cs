using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	//Done
	public AudioSource elementAFired;
	public AudioSource elementBFired;
	public AudioSource elementCFired;

	//Done
	public AudioSource explosionA; 
	public AudioSource explosionB;
	public AudioSource explosionC;

	//Done
	public AudioSource explosionBase;


	public AudioSource powerRecharged;

	public AudioSource backgroundMusic;


	public static SoundManager Singleton = null;

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
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayBackgroundMusic()
	{
		backgroundMusic.Play ();
	}

	public void PlayElementFire(ElementType elementFired)
	{
		switch (elementFired) 
		{
		case ElementType.A:
			elementAFired.Play ();
			break;

		case ElementType.B:
			elementBFired.Play ();
			break;

		case ElementType.C:
			elementCFired.Play ();
			break;

		default:
			break;
		}
	}

	public void PlayElementExplosion(ElementType ExplodedElement)
	{
		switch (ExplodedElement) 
		{
		case ElementType.A:
			explosionA.Play ();
			break;

		case ElementType.B:
			explosionB.Play ();
			break;

		case ElementType.C:
			explosionC.Play ();
			break;

		default:
			break;
		}
	}

	public void PlayBaseExplosion()
	{
		explosionBase.Play ();
	}

	public void PlayPowerRecharged()
	{
		powerRecharged.Play ();
	}


}
