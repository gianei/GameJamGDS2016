using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Color UnselectedColor;
    public Color SelectedColor;

    private Text[] _menuItems;
    private int _selected = 0;
    private bool _isAxisInUse = false;

    // Use this for initialization
    void Start ()
	{
        _menuItems = gameObject.transform.GetComponentsInChildren<Text>();
        MenuChanged();
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            if (_isAxisInUse == false)
            {
                _isAxisInUse = true;

                if (Input.GetAxis("Vertical") > 0)
                    MenuDown();

                if (Input.GetAxis("Vertical") < 0)
                    MenuUp();
            }
        }

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            _isAxisInUse = false;
        }
       

        if (Input.GetButtonDown("Submit"))
            MenuEnter();

	}

    private void MenuDown()
    {
        _selected++;
        _selected = _selected % _menuItems.Length;
        MenuChanged();
    }

    private void MenuUp()
    {
        _selected--;
        if (_selected < 0)
            _selected += _menuItems.Length;
        MenuChanged();
    }

    private void MenuChanged()
    {
        for (int i = 0; i < _menuItems.Length; i++)
        {
            _menuItems[i].color = UnselectedColor;
            if (i == _selected)
                _menuItems[i].color = SelectedColor;
        }
    }

    private void MenuEnter()
    {
        switch (_selected)
        {
            case 0:
                Debug.Log("Start");
                break;
            case 1:
                Debug.Log("Credits");
                break;
        }

    }
}
