using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Movement
{
    [RequireComponent(typeof(Collider2D))]
    public class OnReachedEdge : MonoBehaviour
    {
        [SerializeField] LayerMask layerMask;
        float distance = 0.1f;

        Collider2D enemyCollider;
        float xDirection;

        private void Awake()
        {
            enemyCollider = GetComponent<Collider2D>();
            xDirection = 1f;
        }
        public bool ReachedEdge()
        {
            float x = GetForwardXPosition();
            float y = enemyCollider.bounds.min.y;

            Vector2 origin = new Vector2(x, y);

            Debug.DrawRay(origin, Vector2.down * distance, Color.red);

            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, distance, layerMask);

            if (hit.collider != null) return false;

            SwitchControlDirection();
            return true;
        }

        float GetForwardXPosition()
        {
            return xDirection == -1 ? enemyCollider.bounds.min.x - 0.1f : enemyCollider.bounds.max.x + 0.1f;
        }

        void SwitchControlDirection()
        {
            xDirection *= -1;
        }
    }
}

