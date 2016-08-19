using UnityEngine;

class InputHandler : MonoBehaviour
{
    public GameObject Target = null;

    public InputMap InputMaps = null;

    void Update()
    {
        foreach (InputButton inputButton in InputMaps.Buttons)
        {
            switch (inputButton.Type)
            {
                case InputButton.InputButtonType.Axis:
                    float axis = UnityEngine.Input.GetAxis(inputButton.Name);
                    inputButton.Command.Execute(Target, axis);
                    break;

                case InputButton.InputButtonType.Button:
                    if (UnityEngine.Input.GetButtonDown(inputButton.Name))                      
                        inputButton.Command.Execute(Target);
                    break;
            }
        }
    }
}

