using UnityEngine;

namespace Game
{
    public class BounceBehaviour : IMovable
    {
        Transform ball; 
        float speed;

        public BounceBehaviour(Transform ball, float speed)
        {
            this.ball = ball;
            this.speed = speed;
        }

        public void Move()
        {
            float y = Mathf.PingPong(Time.time * speed, 3);

            ball.position = new Vector3(ball.position.x, y, ball.position.z);
        }
    }
}

