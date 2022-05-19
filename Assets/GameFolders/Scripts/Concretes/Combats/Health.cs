using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Combats
{
    public class Health : MonoBehaviour
    {
        int maxHealth = 5;
        [SerializeField] int currentHealth = 0;

        public bool IsDead => currentHealth < 1;
        public event System.Action OnHealthChanged;
        public event System.Action OnDead;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        public void TakeHit(Damage damage)
        {
            if (IsDead) return;
            currentHealth -= damage.HitDamage;

            if (IsDead)
            {
                OnDead?.Invoke();
            }
            else
            {
                OnHealthChanged?.Invoke();
            }
            
        }
    }
}
