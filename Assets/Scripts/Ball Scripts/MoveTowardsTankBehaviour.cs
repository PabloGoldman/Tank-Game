using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTankBehaviour : IMovable
{
    public void MoveBehaviour(GameObject tank, GameObject ball, float speed)
    {
        ball.transform.position = Vector3.MoveTowards(ball.transform.position, tank.transform.position, speed * Time.deltaTime);
        Debug.Log("Me muevo");
    }
}
