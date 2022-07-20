using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace Game
{
    public class TankInputs : MonoBehaviour
    {
        #region Properties
        private Vector3 reticlePosition;
        public Vector3 ReticlePosition
        {
            get { return reticlePosition; }
        }

        private Vector3 reticleNormal;
        public Vector3 ReticleNormal
        {
            get { return reticleNormal; }
        }

        private float forwardInput;
        public float ForwardInput
        {
            get { return forwardInput; }
        }

        private float rotationInput;
        public float RotationInput
        {
            get { return rotationInput; }
        }
        #endregion

        // Update is called once per frame
        void Update()
        {
            HandleInputs();
        }

        //private void OnDrawGizmos()
        //{
        //    Gizmos.color = Color.red;
        //    Gizmos.DrawSphere(reticlePosition, 0.5f);
        //}

        protected virtual void HandleInputs()
        {
            Ray screenRay = Camera.main.ScreenPointToRay(Input.mousePosition); //Tira un rayo desde la camara hasta la posicion del mouse
            RaycastHit hit;

            if (Physics.Raycast(screenRay, out hit)) //Guarda la data del "golpe"
            {
                reticlePosition = hit.point;
                reticleNormal = hit.normal;
            }
                
            forwardInput = Input.GetAxis("Vertical");  //Seteas el forward input
            rotationInput = Input.GetAxis("Horizontal"); //Seteas el rotation input
        }
    }
}

