using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class BallBehaviour : MonoBehaviour
    {
        [SerializeField] Transform tankTransform;

        [SerializeField] BallsData data;

        public UnityEvent onDestroyBall;

        IMovable typeOfMovement;

        private void Start()
        {
            int random = Random.Range(1, 3);

            if (random == 1)
                typeOfMovement = new MoveTowardsTankBehaviour(tankTransform, transform, data.speedTowardsTank);
            else
                typeOfMovement = new BounceBehaviour(transform, data.upDownSpeed);
        }

        private void Update()
        {
            typeOfMovement.Move();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                GameManager.Get().AddScore();

                onDestroyBall?.Invoke();

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

