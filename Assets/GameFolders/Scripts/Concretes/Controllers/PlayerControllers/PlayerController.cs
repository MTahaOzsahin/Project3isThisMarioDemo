using System.Collections;
using System.Collections.Generic;
using UdemyProjectTutorial3.Abstracts.Inputs;
using UdemyProjectTutorial3.Concretes.Animations;
using UdemyProjectTutorial3.Concretes.Inputs;
using UdemyProjectTutorial3.Concretes.Movement;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Controllers.PlayerControllers
{
    public class PlayerController : MonoBehaviour
    {

        CharacterAnimations characterAnimations;
        Mover mover;
        Jump jump;
        OnGround onGround;
        IPlayerInput input;


        float horizontal;

        

        private void Awake()
        {
            characterAnimations = GetComponent<CharacterAnimations>();
            mover = GetComponent<Mover>();
            jump = GetComponent<Jump>();
            onGround = GetComponent<OnGround>();
            input = new PCInput();
        }

        private void Update()
        {
            GetAxis();
            JumpControl();
        }
        private void FixedUpdate()
        {
            characterAnimations.MoveAnim(horizontal);
            mover.Movement(horizontal);
        }
        void GetAxis()
        {
            horizontal = input.Horizontal;
        }
        void JumpControl()
        {
            if (onGround.IsGround && Input.GetButtonDown("Jump"))
            {
                jump.JumpAction();
            }
            characterAnimations.JumpAnim(jump.IsJumpAction);
        }
        
        
    }
}
