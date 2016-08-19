using UnityEngine;

    class MovePlayerHorizontalCommand : Command
    {
        private const float ForwardSpeed = 15.0f;


        public override void MakeAction(GameObject target, params object[] args)
        {
            if (target == null)
                return;

            float speed = (float)args[0];
            speed = Mathf.Clamp(speed, -1, 1);

            Rigidbody2D rigidbody = target.GetComponent<Rigidbody2D>();

            float y = rigidbody.velocity.y;

            rigidbody.velocity = new Vector2(Mathf.Lerp(0, speed*ForwardSpeed, 0.8f), y);
            

        }

    }

