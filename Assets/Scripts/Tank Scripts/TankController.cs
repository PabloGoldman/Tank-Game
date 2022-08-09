using System.Collections;
using UnityEngine;
using UnityEngine.Events;

//Codigo basado en:
//https://www.youtube.com/watch?v=Ho6eR5-mfyA&ab_channel=Indie-Pixel

namespace Game
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(TankInputs))]
    public class TankController : MonoBehaviour
    {
        [Header("Movement")]
        public float tankSpeed = 15f;
        public float tankRotationSpeed = 20f;

        [Header("Reticle")]
        public Transform reticleTransform;

        [Header("Turret")]
        public Transform turretTransform;
        public float turretSpeed = 0.5f;

        public UnityEvent onShoot;

        Rigidbody rb;
        TankInputs input;

        private Vector3 actualTurretDirection;

        [SerializeField] Animator[] animator;

        [SerializeField] ParticleSystem shootFlash;

        Coroutine shootCoroutine;

        bool canTurretRotate = true;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            input = GetComponent<TankInputs>();
        }

        private void Update()
        {
            HandleTurret();
            HandleAnimations();
        }

        private void FixedUpdate()
        {
            if (rb && input)
            {
                HandleMovement();
                HandleReticle();
            }
        }

        //Los hago virtuales ya que si se quisieran hacer mas tipos de movimiento solo tendriamos que heredar de esta clase y overridear los metodos

        protected virtual void HandleMovement()
        {
            Vector3 wantedPosition = transform.position + (transform.forward * input.ForwardInput * tankSpeed * Time.deltaTime);

            rb.MovePosition(wantedPosition);

            Quaternion wantedRotation = transform.rotation * Quaternion.Euler(Vector3.up * input.RotationInput * tankRotationSpeed * Time.deltaTime);
            rb.MoveRotation(wantedRotation);
        }

        protected virtual void HandleTurret()
        {
            if (Input.GetMouseButtonDown(0) && canTurretRotate)
            {
                if (shootCoroutine != null)
                {
                    StopCoroutine(shootCoroutine);
                }
                shootCoroutine = StartCoroutine(RotateTurretTowardsPointCoroutine());
            }
        }

        protected virtual void HandleReticle()
        {
            if (reticleTransform)
            {
                reticleTransform.position = input.ReticlePosition;
            }
        }


        private void HandleAnimations()
        {
            if (input.ForwardInput != 0 || input.RotationInput != 0 || rb.velocity.sqrMagnitude > 0.1f) //Si me muevo manualmente, o si me estoy "cayendo"
            {
                foreach (Animator animator in animator)
                {
                    animator.SetTrigger("PlayAnim");
                }
            }
            else
            {
                foreach (Animator animator in animator)
                {
                    animator.SetTrigger("StopAnim");
                }
            }
        }

        IEnumerator RotateTurretTowardsPointCoroutine()
        {
            canTurretRotate = false;

            float time = 0.0f;

            Vector3 turretLookDir = input.ReticlePosition - turretTransform.position; //Setea el punto a rotar

            turretLookDir.y = 0f;

            actualTurretDirection = turretTransform.forward; //Seteo su direccion actual como su forward, a donde esta apuntando

            while (actualTurretDirection != turretLookDir)
            {
                time += Time.deltaTime * turretSpeed;

                actualTurretDirection = Vector3.Slerp(actualTurretDirection, turretLookDir, time);

                turretTransform.rotation = Quaternion.LookRotation(actualTurretDirection);

                yield return null;
            }

            shootFlash.Play();
            onShoot?.Invoke();
            canTurretRotate = true;
        }
    }

}


