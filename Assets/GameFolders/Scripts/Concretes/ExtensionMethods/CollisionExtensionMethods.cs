using System.Collections;
using System.Collections.Generic;
using UdemyProjectTutorial3.Concretes.Combats;
using UdemyProjectTutorial3.Concretes.Controllers.EnemiesController;
using UdemyProjectTutorial3.Concretes.Controllers.PlayerControllers;
using UnityEngine;
namespace UdemyProjectTutorial3.Concretes.ExtensionMethods
{
    public static class CollisionExtensionMethods
    {
        // Collision2D classýna eklenti yazmýþ olduk böylece gereken yerlere burada yazdýðýmýz classlarý yazabiliriz direkt.
        public static bool WasHitRightOrLeftSide(this Collision2D collision)
        {
            return collision.contacts[0].normal.x > 0.6f || collision.contacts[0].normal.x < -0.6f;
        }
        public static bool WasHitBottomSide(this Collision2D collision)
        {
            return collision.contacts[0].normal.y < -0.6f;
        }
        public static bool WasHitTopSide(this Collision2D collision)
        {
            return collision.contacts[0].normal.y > 0.6f;
        }
        public static bool HasHitPlayer(this Collision2D collision)
        {
            return collision.collider.GetComponent<PlayerController>() != null;
        }
        public static bool HasHitEnemy(this Collision2D collision)
        {
            return collision.collider.GetComponent<EnemyController>() != null;
        }
        public static Health ObjectHasHealth(this Collision2D collision)
        {
            Health health = collision.collider.GetComponent<Health>();
            if (health != null)
            {
                return health;
            }
            return null;
        }
    }
}


