using UnityEngine;

namespace Game
{
    public class BallBehaviour : MonoBehaviour
    {
        [SerializeField] GameObject tankObject;

        [SerializeField] BallsData data;

        IMovable typeOfMovement;

        private void Start()
        {
            int random = Random.Range(1, 3);

            if (random == 1)
                typeOfMovement = new MoveTowardsTankBehaviour(tankObject, gameObject, data.speedTowardsTank);
            else
                typeOfMovement = new BounceBehaviour(gameObject, data.upDownSpeed);
        }

        private void Update()
        {
            typeOfMovement.MoveBehaviour();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                GameManager.Get().AddScore();

                collision.gameObject.SetActive(false);
                Destroy(gameObject);
            }

            if (collision.gameObject.tag == "Player")
            {
                GameManager.Get().GameOver();
            }
        }
    }
}

