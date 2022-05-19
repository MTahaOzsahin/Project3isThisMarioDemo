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

        public event System.Action<bool> OnSceneChanged;
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

            int buildIndex = SceneManager.GetActiveScene().buildIndex;

            yield return SceneManager.UnloadSceneAsync(buildIndex);

            SceneManager.LoadSceneAsync(buildIndex + LevelIndex, LoadSceneMode.Additive).completed += (AsyncOperation obj) =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(buildIndex + LevelIndex));
            };

            OnSceneChanged?.Invoke(false);
        }

        public void LoadMenuAndUi(float delayLoadingTime)
        {
            StartCoroutine(LoadMenuAndUiAsync(delayLoadingTime));
        }

        IEnumerator LoadMenuAndUiAsync(float delayLoadingTime)
        {
            yield return new WaitForSeconds(delayLoadingTime);
            yield return SceneManager.LoadSceneAsync("Menu");
            yield return SceneManager.LoadSceneAsync("Ui", LoadSceneMode.Additive);

            OnSceneChanged?.Invoke(true);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}

