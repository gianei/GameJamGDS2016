using UnityEngine;


    class MovePlayerVerticalCommand : Command
    {
        private const float ForwardSpeed = 15.0f;


        public override void MakeAction(GameObject target, params object[] args)
        {
            if (target == null)
                return;

            float speed = (float)args[0];
            speed = Mathf.Clamp(speed, -1, 1);

            Rigidbody2D rigidbody = target.GetComponent<Rigidbody2D>();

            float x = rigidbody.velocity.x;
              
            rigidbody.velocity = new Vector2(x, Mathf.Lerp(0, speed * ForwardSpeed, 0.8f));

        }

    }
