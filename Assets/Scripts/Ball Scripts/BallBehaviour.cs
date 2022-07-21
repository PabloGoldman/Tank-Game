using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField] GameObject tankObject;

    [SerializeField] float speed;

    IMovable typeOfMovement;

    private void Start()
    {
        //typeOfMovement = new MoveTowardsTankBehaviour();

        typeOfMovement = new BounceBehaviour();
    }

    private void Update()
    {
        typeOfMovement.MoveBehaviour(tankObject, gameObject, speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}