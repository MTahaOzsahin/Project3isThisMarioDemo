using System.Collections;
using System.Collections.Generic;
using UdemyProjectTutorial3.Abstracts.Inputs;
using UdemyProjectTutorial3.Concretes.Animations;
using UdemyProjectTutorial3.Concretes.Combats;
using UdemyProjectTutorial3.Concretes.Inputs;
using UdemyProjectTutorial3.Concretes.Movement;
using UdemyProjectTutorial3.Concretes.Uis;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Controllers.PlayerControllers
{
    public class PlayerController : MonoBehaviour
    {

        CharacterAnimations characterAnimations;
        Mover mover;
        Jump jump;
        OnGround onGround;
        Climbing climbing;
        Health health;
        IPlayerInput input;


        float horizontal;
        float vertical;

        

        private void Awake()
        {
            characterAnimations = GetComponent<CharacterAnimations>();
            mover = GetComponent<Mover>();
            jump = GetComponent<Jump>();
            onGround = GetComponent<OnGround>();
            climbing = GetComponent<Climbing>();
            health = GetComponent<Health>();
            input = new PCInput();
        }
        private void OnEnable()
        {
            GameCanvas gameCanvas = FindObjectOfType<GameCanvas>();

            if (gameCanvas != null)
            {
                health.OnDead += gameCanvas.ShowGameOverPanel;
                DisplayHealth displayHealth = gameCanvas.GetComponentInChildren<DisplayHealth>();
                health.OnHealthChanged += displayHealth.WriteHealth;
            }
        }
        private void Update()
        {
            GetAxis();
            JumpControl();
        }
        private void FixedUpdate()
        {
            characterAnimations.MoveAnim(horizontal);
            characterAnimations.ClimbAnim(climbing.IsCharacterClimbing);
            mover.Movement(horizontal);
            ClimbControl();
        }
        void GetAxis()
        {
            if (health.IsDead) return;
            horizontal = input.Horizontal;
            vertical = input.Vertical;
        }
        void JumpControl()
        {
            bool IsJumpAction = false;
            if (onGround.IsGround && Input.GetButtonDown("Jump") && !climbing.IsCharacterClimbing)
            {
                IsJumpAction = true;
                jump.JumpAction();
            }
            else if (!onGround.IsGround)
            {
                IsJumpAction = true;
            }
            else if (onGround.IsGround)
            {
                IsJumpAction = false;
            }
           
            characterAnimations.JumpAnim(IsJumpAction);
        }
        void ClimbControl()
        {
            climbing.ClimbAction(vertical);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Damage damage = collision.collider.GetComponent<Damage>();
            if (damage != null)
            {
                health.TakeHit(damage);
                //damage.HitTerget(health);  Bu da çalýþýr.
            }
            return;
        }

    }
}
