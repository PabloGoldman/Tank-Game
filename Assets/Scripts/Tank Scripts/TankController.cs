using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        Rigidbody rb;
        TankInputs input;

        private Vector3 actualTurretDirection;

        bool canTurretRotate = true;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            input = GetComponent<TankInputs>();
        }

        private void Update()
        {
            HandleTorret();
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

        protected virtual void HandleTorret()
        {
            if (Input.GetMouseButtonDown(0) && canTurretRotate)
            {
                StartCoroutine(RotateTurretTowardsPointCoroutine());
            }
        }

        protected virtual void HandleReticle()
        {
            if (reticleTransform)
            {
                reticleTransform.position = input.ReticlePosition;
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

            canTurretRotate = true;
        }
    }

}


