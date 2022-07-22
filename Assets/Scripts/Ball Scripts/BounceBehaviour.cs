using UnityEngine;

namespace Game
{
    public class BounceBehaviour : IMovable
    {
        public void MoveBehaviour(GameObject tank, GameObject ball, float speed)
        {
            float y = Mathf.PingPong(Time.time * speed, 3);

            ball.transform.position = new Vector3(ball.transform.position.x, y, ball.transform.position.z);
        }
    }
}

