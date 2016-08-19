using UnityEngine;
using System.Collections;

class PlayerInputMap : InputMap {

    public PlayerInputMap()
    {
        this.Buttons = new InputButton[2];
        this.Buttons[0] = new InputButton("Vertical", new ControlVerticalGravity(), InputButton.InputButtonType.Axis);
        this.Buttons[1] = new InputButton("Horizontal", new SpinThePlayer(), InputButton.InputButtonType.Axis);
    }
}
