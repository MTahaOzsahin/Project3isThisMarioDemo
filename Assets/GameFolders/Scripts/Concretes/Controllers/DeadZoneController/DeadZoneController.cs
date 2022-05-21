using System.Collections;
using System.Collections.Generic;
using UdemyProjectTutorial3.Concretes.Combats;
using UdemyProjectTutorial3.Concretes.ExtensionMethods;
using UnityEngine;
namespace UdemyProjectTutorial3.Concretes.Controllers.DeadZoneController
{
    public class DeadZoneController : MonoBehaviour
    {
        Damage damage;

        private void Awake()
        {
            damage = GetComponent<Damage>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health health = collision.ObjectHasHealth();

            if (health != null)
            {
                health.TakeHit(damage);
            }
        }
    }
}


