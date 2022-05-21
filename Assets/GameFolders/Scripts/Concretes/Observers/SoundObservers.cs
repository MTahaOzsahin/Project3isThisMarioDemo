using System.Collections;
using System.Collections.Generic;
using UdemyProjectTutorial3.Concretes.Combats;
using UdemyProjectTutorial3.Concretes.Controllers.EnemiesController;
using UdemyProjectTutorial3.Concretes.Controllers.PlayerControllers;
using UdemyProjectTutorial3.Concretes.Controllers.ScoreContoller;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Observers
{
    public class SoundObservers : MonoBehaviour
    {
        AudioSource audioSource;
        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }
        private void OnEnable()
        {
            PlayerController.OnPLayerDead += PlaySoundOneShot;
            EnemyController.OnEnemyDead += PlaySoundOneShot;
            ScoreController.OnScoreSoundClip += PlaySoundOneShot;
        }
        private void OnDisable()
        {
            PlayerController.OnPLayerDead -= PlaySoundOneShot;
            EnemyController.OnEnemyDead -= PlaySoundOneShot;
            ScoreController.OnScoreSoundClip -= PlaySoundOneShot;
        }

        void PlaySoundOneShot(AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}

