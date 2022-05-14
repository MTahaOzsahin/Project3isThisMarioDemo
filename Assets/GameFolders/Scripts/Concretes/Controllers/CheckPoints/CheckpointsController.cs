using System.Collections;
using System.Collections.Generic;
using UdemyProjectTutorial3.Concretes.Controllers.PlayerControllers;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Controllers.CheckPoints
{
    public class CheckpointsController : MonoBehaviour
    {
        bool isPassed = false;
        public bool IsPassed => isPassed;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerController>() != null)
            {
                isPassed = true;
            }
        }
    }
}
