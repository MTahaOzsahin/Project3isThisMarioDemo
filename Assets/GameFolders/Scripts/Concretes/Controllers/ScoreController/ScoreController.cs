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
        [SerializeField] AudioClip scoreClip;

        public static event System.Action<AudioClip> OnScoreSoundClip;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null)
            {
                GameManager.Instance.IncreaseScore(score);

                OnScoreSoundClip.Invoke(scoreClip);

                Destroy(this.gameObject);
            }
        }
    }
}

