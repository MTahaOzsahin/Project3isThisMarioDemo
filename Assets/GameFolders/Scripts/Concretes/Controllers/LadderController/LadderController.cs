using System.Collections;
using System.Collections.Generic;
using UdemyProjectTutorial3.Concretes.Movement;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Controllers.LadderController
{
    public class LadderController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            EnterExitOnTrigger(collision, 0f, true);
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            EnterExitOnTrigger(collision, 1f, false);
        }
        void EnterExitOnTrigger(Collider2D collision, float gravityScale, bool isClimbing)
        {
            Climbing player = collision.GetComponent<Climbing>();

            if (player != null)
            {
                player.CharacterRigidbody2D.gravityScale = gravityScale;
                player.IsCharacterClimbing = isClimbing;
                player.CharacterRigidbody2D.velocity = Vector2.zero;
            }
        }
    }
}
