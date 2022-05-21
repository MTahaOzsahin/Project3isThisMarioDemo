using System.Collections;
using System.Collections.Generic;
using UdemyProjectTutorial3.Abstracts.Inputs;
using UdemyProjectTutorial3.Concretes.Animations;
using UdemyProjectTutorial3.Concretes.Combats;
using UdemyProjectTutorial3.Concretes.Controllers.EnemiesController;
using UdemyProjectTutorial3.Concretes.ExtensionMethods;
using UdemyProjectTutorial3.Concretes.Inputs;
using UdemyProjectTutorial3.Concretes.Movement;
using UdemyProjectTutorial3.Concretes.Uis;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Controllers.PlayerControllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] AudioClip deadClip;

        CharacterAnimations characterAnimations;
        Mover mover;
        Jump jump;
        OnGround onGround;
        Climbing climbing;
        Health health;
        Damage damage;
        AudioSource audioSource;
        IPlayerInput input;


        float horizontal;
        float vertical;

        public static event System.Action<AudioClip> OnPLayerDead;

        private void Awake()
        {
            characterAnimations = GetComponent<CharacterAnimations>();
            mover = GetComponent<Mover>();
            jump = GetComponent<Jump>();
            onGround = GetComponent<OnGround>();
            climbing = GetComponent<Climbing>();
            health = GetComponent<Health>();
            damage = GetComponent<Damage>();
            audioSource = GetComponent<AudioSource>();
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

            health.OnDead += () => OnPLayerDead(deadClip);

            health.OnHealthChanged += PlaySoundOnHit;
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
            Health health = collision.ObjectHasHealth();

            if (health != null && collision.WasHitTopSide())
            {
                health.TakeHit(damage);
                jump.JumpAction();
            }

            //Damage damage = collision.collider.GetComponent<Damage>();
            //if (collision.HasHitEnemy() && collision.WasHitRightOrLeftSide())
            //{
            //    //health.TakeHit(damage); Bu da çalýþýr.
            //    damage.HitTarget(health);
            //    return;
            //}
            //if (damage != null && !collision.HasHitEnemy())
            //{
            //    damage.HitTarget(health);
            //}

        }

        void PlaySoundOnHit(int currentHealth, int maxHealth)
        {
            if (currentHealth == maxHealth) return;
            audioSource.Play();
        }
    }
}
