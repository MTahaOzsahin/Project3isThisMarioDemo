using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProjectTutorial3.Concretes.Managers
{
    public class GameManager : MonoBehaviour
    {
        float delayLevelTime = 1f;

        public static GameManager Instance { get; private set; }
        private void Awake()
        {
            SingetonThisGameObject();
        }

        private void SingetonThisGameObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void LoadScene(int LevelIndex = 0)
        {
            StartCoroutine(LoadSceneAsync(LevelIndex));
        }

        IEnumerator LoadSceneAsync(int LevelIndex)
        {
            yield return new WaitForSeconds(delayLevelTime);
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + LevelIndex);
        }
    }
}

