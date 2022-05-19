using System.Collections;
using System.Collections.Generic;
using UdemyProjectTutorial3.Concretes.Managers;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Uis
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesButtonClick()
        {
            GameManager.Instance.LoadScene();
            this.gameObject.SetActive(false);
        }
        public void NoButtonClick()
        {
            GameManager.Instance.LoadMenuAndUi(2f);
        }
    }
}
