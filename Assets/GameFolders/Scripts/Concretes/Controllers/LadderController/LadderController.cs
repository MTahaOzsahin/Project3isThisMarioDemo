using System.Collections;
using System.Collections.Generic;
using UdemyProjectTutorial3.Concretes.Controllers.PlayerControllers;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Controllers.LadderController
{
    public class LadderController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null)
            {

            }
        }
    }
}
