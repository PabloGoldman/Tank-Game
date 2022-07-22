using UnityEngine;

namespace Game
{
    public class BounceBehaviour : IMovable
    {
        GameObject ball; 
        float speed;

        public BounceBehaviour(GameObject ball, float speed)
        {
            this.ball = ball;
            this.speed = speed;
        }

        public void MoveBehaviour()
        {
            float y = Mathf.PingPong(Time.time * speed, 3);

            ball.transform.position = new Vector3(ball.transform.position.x, y, ball.transform.position.z);
        }
    }
}

