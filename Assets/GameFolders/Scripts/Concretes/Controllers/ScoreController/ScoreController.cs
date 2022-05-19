using System.Collections;
using System.Collections.Generic;
using UdemyProjectTutorial3.Concretes.Controllers.PlayerControllers;
using UdemyProjectTutorial3.Concretes.Managers;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Controllers.ScoreContoller
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] int score = 1;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null)
            {
                GameManager.Instance.IncreaseScore(score);

                Destroy(this.gameObject);
            }
        }
    }
}

