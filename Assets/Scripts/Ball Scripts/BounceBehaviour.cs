using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBehaviour : IMovable
{
    public void MoveBehaviour(GameObject tank, GameObject ball, float speed)
    {
        float y = Mathf.PingPong(Time.time * speed, 3);

        ball.transform.position = new Vector3(ball.transform.position.x, y, ball.transform.position.z);
    }
}
