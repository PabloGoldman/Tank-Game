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
            }
        }

        protected virtual void HandleMovement()
        {
            Vector3 wantedPosition = transform.position + (transform.forward * input.ForwardInput * tankSpeed * Time.deltaTime);
            rb.MovePosition(wantedPosition);

            Quaternion wantedRotation = transform.rotation * Quaternion.Euler(Vector3.up * tankRotationSpeed);
            rb.MoveRotation(wantedRotation);
        }
    }
}


