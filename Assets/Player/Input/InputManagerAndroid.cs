using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class InputManagerAndroid : MonoBehaviour {

    public Canvas elementSelectionCanvas;

    float canvasYlimit;

	// Use this for initialization
	void Start () {
        canvasYlimit = elementSelectionCanvas.transform.position.y;
        Debug.Log("Y: " + canvasYlimit);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.touchCount>0 && Input.GetTouch(0).tapCount > 0)
        {
            if(Input.GetTouch(0).phase==TouchPhase.Began)
            {
                Vector3 worldTouchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                if(worldTouchPosition.y > this.canvasYlimit)
                {
                    PlayerManager.Singleton.FireProjectile(worldTouchPosition);
                }
            }
        }
	}

    public void ElementAButtonOnClick()
    {
        PlayerManager.Singleton.SwitchElementActivation(ElementType.A);
    }
    public void ElementBButtonOnClick()
    {
        PlayerManager.Singleton.SwitchElementActivation(ElementType.B);
    }
    public void ElementCButtonOnClick()
    {
        PlayerManager.Singleton.SwitchElementActivation(ElementType.C);
    }
}
