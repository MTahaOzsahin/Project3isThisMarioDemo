using System.Collections;
using System.Collections.Generic;
using UdemyProjectTutorial3.Concretes.Animations;
using UdemyProjectTutorial3.Concretes.Combats;
using UdemyProjectTutorial3.Concretes.Controllers.PlayerControllers;
using UdemyProjectTutorial3.Concretes.Movement;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Controllers.EnemiesController
{
    public class EnemyController : MonoBehaviour
    {
        CharacterAnimations characterAnimations;
        Mover mover;
        Health health;
        OnReachedEdge onReachedEdge;

        bool isOnEdge;
        float direction;
        private void Awake()
        {
            characterAnimations = GetComponent<CharacterAnimations>();
            mover = GetComponent<Mover>();
            health = GetComponent<Health>();
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
            Damage damage = collision.collider.GetComponent<Damage>();

            if (collision.collider.GetComponent<PlayerController>() != null &&
                collision.contacts[0].normal.y < -0.6f)
            {
                damage.HitTarget(health);
            }
        }

        void DeadAction()
        {
            Destroy(this.gameObject);
        }
    }
}

