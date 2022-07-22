using UnityEngine;

namespace Game
{
    public class MoveTowardsTankBehaviour : IMovable
    {
        GameObject tank;
        GameObject ball;
        float speed;

        public MoveTowardsTankBehaviour(GameObject tank, GameObject ball, float speed)
        {
            this.tank = tank;
            this.ball = ball;
            this.speed = speed;
        }

        public void MoveBehaviour()
        {
            ball.transform.position = Vector3.MoveTowards(ball.transform.position, tank.transform.position, speed * Time.deltaTime);
        }
    }
}


