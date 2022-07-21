using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBehaviour : IMovable
{
    public void MoveBehaviour(GameObject tank, GameObject ball, float speed)
    {
        float t = 0;

        t += Time.deltaTime;

        Vector3 from = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);
        Vector3 to = new Vector3(ball.transform.position.x, ball.transform.position.y + 20, ball.transform.position.z);

        ball.transform.position = Vector3.Lerp(from, to, t);
    }
}
