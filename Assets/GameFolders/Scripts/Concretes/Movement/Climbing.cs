using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Movement
{
    public class Climbing : MonoBehaviour
    {
        Rigidbody2D characterRigiBody2D;
        public Rigidbody2D CharacterRigidbody2D => characterRigiBody2D;
        public bool IsCharacterClimbing { get; set; }

        private void Awake()
        {
            characterRigiBody2D = GetComponent<Rigidbody2D>();
        }

        public void ClimbAction (float direction)
        {
            if (IsCharacterClimbing)
            {
                transform.Translate(Vector2.up * direction * Time.deltaTime * 5f);
            }
           
        }
    }
}
