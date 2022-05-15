using System.Collections;
using System.Collections.Generic;
using UdemyProjectTutorial3.Concretes.Managers;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Uis
{
    public class MenuPanel : MonoBehaviour
    {
        public void StartButton()
        {
            GameManager.Instance.LoadScene(1);
        }

        public void ExitButton()
        {
            GameManager.Instance.ExitGame();
        }
    }
}
