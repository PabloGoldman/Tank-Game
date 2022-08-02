using UnityEngine;

namespace Game
{
    public class MoveTowardsTankBehaviour : IMovable
    {
        Transform tank;
        Transform ball;
        float speed;

        public MoveTowardsTankBehaviour(Transform tank, Transform ball, float speed)
        {
            this.tank = tank;
            this.ball = ball;
            this.speed = speed;
        }

        public void Move()
        {
            ball.position = Vector3.MoveTowards(ball.position, tank.position, speed * Time.deltaTime);
        }
    }
}


