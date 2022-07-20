using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        Rigidbody rb;
        TankInputs input;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            input = GetComponent<TankInputs>();
        }

        private void FixedUpdate()
        {
            if (rb && input)
            {
                HandleMovement();
                HandleTorret();
                HandleReticle();
            }
        }

        //Los hago virtuales ya que si se quisieran hacer mas tipos de movimiento solo tendriamos que heredar de esta clase

        protected virtual void HandleMovement()
        {
            Vector3 wantedPosition = transform.position + (transform.forward * input.ForwardInput * tankSpeed * Time.deltaTime);
            rb.MovePosition(wantedPosition);

            Quaternion wantedRotation = transform.rotation * Quaternion.Euler(Vector3.up * input.RotationInput * tankRotationSpeed * Time.deltaTime);
            rb.MoveRotation(wantedRotation);
        }

        protected virtual void HandleTorret()
        {
            if (turretTransform)
            {
                Vector3 turretLookDir = input.ReticlePosition - turretTransform.position;

                turretTransform.rotation = Quaternion.LookRotation(turretLookDir);
            }
        }

        protected virtual void HandleReticle()
        {
            if (reticleTransform)
            {
                reticleTransform.position = input.ReticlePosition;
            }
        }
    }
}


