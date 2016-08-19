
    class Player1InputMap : InputMap
    {
        public Player1InputMap()
        {
            Buttons = new InputButton[2];
            Buttons[0] = new InputButton("Horizontal", new MovePlayerHorizontalCommand(), InputButton.InputButtonType.Axis);
            Buttons[1] = new InputButton("Vertical", new MovePlayerVerticalCommand(), InputButton.InputButtonType.Axis);
        }
    }

