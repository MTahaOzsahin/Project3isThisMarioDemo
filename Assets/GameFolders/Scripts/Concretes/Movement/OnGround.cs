using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Movement
{
    public class OnGround : MonoBehaviour
    {
        [SerializeField] bool isGround = false;
        [SerializeField] Transform[] translates;
        [SerializeField] LayerMask layerMask;

        public bool IsGround => isGround;

        private void Update()
        {
            foreach (Transform footTransform in translates)
            {
                CheckFootOnGround(footTransform);

                if (isGround) break;
                
            }
        }

        private void CheckFootOnGround(Transform footTransform)
        {
            RaycastHit2D hit = Physics2D.Raycast(footTransform.position, footTransform.forward, 0.15f, layerMask);
            Debug.DrawRay(footTransform.position, footTransform.forward * 0.15f, Color.red);

            if (hit.collider != null)
            {
                isGround = true;
            }
            else
            {
                isGround = false;
            }
        }
    }

}