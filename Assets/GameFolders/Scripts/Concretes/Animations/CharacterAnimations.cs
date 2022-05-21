using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Animations
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimations : MonoBehaviour
    {
        Animator playerAnimator;
        private void Awake()
        {
            playerAnimator = GetComponent<Animator>();
        }
        public void MoveAnim(float horizontal)
        {
            float mathfValue = Mathf.Abs(horizontal);
            if (playerAnimator.GetFloat("movementSpeed") == mathfValue) return;
            
            playerAnimator.SetFloat("movementSpeed" , mathfValue);
        }
        public void JumpAnim(bool notOnGround)
        {
            playerAnimator.SetBool("isJump", notOnGround);
        }
        
        public void ClimbAnim (bool isClimbing)
        {
            if (playerAnimator.GetBool("isClimb") == isClimbing) return;

            playerAnimator.SetBool("isClimb", isClimbing);
        }
        public void DeathAnim()
        {
            playerAnimator.SetTrigger("Death");
        }
    }
}

