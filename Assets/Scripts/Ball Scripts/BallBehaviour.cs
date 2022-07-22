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
        int random = Random.Range(1, 3);

        if (random == 1)
        {
            typeOfMovement = new MoveTowardsTankBehaviour();
        }
        else
        {
            typeOfMovement = new BounceBehaviour();
        }

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