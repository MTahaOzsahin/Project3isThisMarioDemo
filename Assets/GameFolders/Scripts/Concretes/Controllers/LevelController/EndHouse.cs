using System.Collections;
using System.Collections.Generic;
using UdemyProjectTutorial3.Concretes.Controllers.PlayerControllers;
using UdemyProjectTutorial3.Concretes.Managers;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Controllers.LevelController
{
    public class EndHouse : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                GameManager.Instance.LoadScene();
            }
        }
    }
}
