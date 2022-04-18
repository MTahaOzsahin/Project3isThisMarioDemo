using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Controllers.PlayerControllers
{
    public class PlayerController : MonoBehaviour
    {
        Animator playerAnimator;


        float horizontal;
        private void Awake()
        {
            playerAnimator = GetComponent<Animator>();
        }

        private void Update()
        {
            GetAxis();
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
    }
}
