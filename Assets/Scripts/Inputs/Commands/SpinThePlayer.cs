using UnityEngine;
using System.Collections;
using System;

public class SpinThePlayer : Command
{
    public float spinSpeed = 5f;

    public override void MakeAction(GameObject target, params object[] args)
    {
        Rigidbody2D targetRigidBody = target.gameObject.GetComponent<Rigidbody2D>();

        float axisDirection = (float)args[0];
        if (axisDirection > 0)
        {
            targetRigidBody.AddTorque(-spinSpeed);
        }
        else if (axisDirection < 0)
        {
            targetRigidBody.AddTorque(+spinSpeed);
        }
    }
}
