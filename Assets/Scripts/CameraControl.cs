using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public GameObject playerToBeFollowed;
    public float cameraOffset;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newCameraPosition = new Vector3(playerToBeFollowed.transform.position.x, playerToBeFollowed.transform.position.y, -10);
        this.gameObject.transform.position = newCameraPosition;
	}
}
