using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Controllers.PlayerControllers
{
    public class PlayerController : MonoBehaviour
    {
        Animator playerAnimator;
        Rigidbody2D playerRigibody2D;


        float horizontal;
        bool isJump;

        public bool IsJumpAction => playerRigibody2D.velocity != Vector2.zero; // sýfýrdan büyükse true döner.

        private void Awake()
        {
            playerAnimator = GetComponent<Animator>();
            playerRigibody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            GetAxis();
            JumpAction();
        }
        private void FixedUpdate()
        {
            Movement();
        }
        void GetAxis()
        {
             horizontal = Input.GetAxis("Horizontal");
        }
        void Movement()
        {
            
            playerAnimator.SetFloat("movementSpeed",Mathf.Abs(horizontal));
            transform.Translate(Vector2.right * horizontal * Time.deltaTime * 12f);
            if (horizontal != 0)
            {
                transform.localScale = new Vector2(Mathf.Sign(horizontal), 1f);
            }
        }
        void JumpAction()
        {
            if (Input.GetButtonDown("Jump"))
            {
                isJump = true;
            }
            if (isJump)
            {
                playerRigibody2D.AddForce(Vector2.up * 350f);
                isJump = false;
            }
            playerAnimator.SetBool("isJump", IsJumpAction);
        }
    }
}
