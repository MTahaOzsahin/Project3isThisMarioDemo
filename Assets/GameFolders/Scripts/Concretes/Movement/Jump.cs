using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jump : MonoBehaviour
    {
        Rigidbody2D playerRigibody2D;

        public bool IsJumpAction => playerRigibody2D.velocity != Vector2.zero; // sýfýrdan büyükse true döner. 

        private void Awake()
        {
            playerRigibody2D = GetComponent<Rigidbody2D>();
        }

        public void JumpAction()
        {      
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerRigibody2D.velocity = Vector2.zero;
                playerRigibody2D.AddForce(Vector2.up * 500f);
            }
            else
            {
                playerRigibody2D.velocity = Vector2.zero;
                playerRigibody2D.AddForce(Vector2.up * 350f);

            }
        }
    }
}
