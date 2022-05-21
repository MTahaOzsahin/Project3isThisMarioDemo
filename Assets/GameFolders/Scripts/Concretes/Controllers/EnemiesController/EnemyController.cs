using System.Collections;
using System.Collections.Generic;
using UdemyProjectTutorial3.Concretes.Animations;
using UdemyProjectTutorial3.Concretes.Combats;
using UdemyProjectTutorial3.Concretes.Controllers.PlayerControllers;
using UdemyProjectTutorial3.Concretes.ExtensionMethods;
using UdemyProjectTutorial3.Concretes.Movement;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Controllers.EnemiesController
{
    public class EnemyController : MonoBehaviour
    {
        CharacterAnimations characterAnimations;
        Mover mover;
        Health health;
        Damage damage;
        OnReachedEdge onReachedEdge;

        bool isOnEdge;
        float direction;
        private void Awake()
        {
            characterAnimations = GetComponent<CharacterAnimations>();
            mover = GetComponent<Mover>();
            health = GetComponent<Health>();
            damage = GetComponent<Damage>();
            onReachedEdge = GetComponent<OnReachedEdge>();
            direction = 1f;
        }
        private void OnEnable()
        {
            health.OnDead += DeadAction;
        }
       

        private void FixedUpdate()
        {
            if (health.IsDead) return;

            
            mover.Movement(direction);
            characterAnimations.MoveAnim(direction);
            
        }
        private void LateUpdate()
        {
            if (health.IsDead) return;
            if (onReachedEdge.ReachedEdge())
            {
                direction *= -1;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health health = collision.ObjectHasHealth();

            if (health != null && collision.WasHitRightOrLeftSide())
            {
                health.TakeHit(damage);
            }
        }
        IEnumerator DeadActionAsync()
        {
            characterAnimations.DeathAnim();
            yield return new WaitForSeconds(0.5f);
            Destroy(this.gameObject);
        }
        void DeadAction()
        {
            StartCoroutine(DeadActionAsync());
        }
    }
}

