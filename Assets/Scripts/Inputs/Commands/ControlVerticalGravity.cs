using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ControlVerticalGravity : Command
{
	public float normalGravity = 1f; //Default value
	public float gravityOffset = 0.2f; //Default value

    public override void MakeAction(GameObject target, params object[] args)
    {
        Rigidbody2D targetRigidBody = target.gameObject.GetComponent<Rigidbody2D>();

        float axisDirection = (float) args[0];
        if(axisDirection > 0)
        {
			targetRigidBody.gravityScale = normalGravity + gravityOffset;
        }
        else if(axisDirection < 0)
        {
			targetRigidBody.gravityScale = normalGravity - gravityOffset;
        }
        else if(axisDirection == 0)
        {
			targetRigidBody.gravityScale = normalGravity;
        }

		Debug.Log("current gravity: " + targetRigidBody.gravityScale);

    }
}
