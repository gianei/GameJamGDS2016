using System;
using UnityEngine;

    public abstract class Command
    {
        

        public void Execute(GameObject target, params object[] args)
        {
            if (target == null)
                return;

            MakeAction(target, args);
        }

        public abstract void MakeAction(GameObject target, params object[] args);


    }

