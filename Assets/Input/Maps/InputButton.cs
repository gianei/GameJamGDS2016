using System;

    class InputButton
    {
        public String Name;
        public Command Command;
        public InputButtonType Type;

        public enum InputButtonType
        {
            Button = 1 ,
            Axis = 2
        }

        public InputButton(String name, Command command, InputButtonType type)
        {
            this.Name = name;
            this.Command = command;
            this.Type = type;
        }

    }

    

