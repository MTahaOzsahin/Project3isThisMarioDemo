using System.Collections;
using System.Collections.Generic;
using UdemyProjectTutorial3.Concretes.Managers;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Uis
{
    public class LoadingCanvas : MonoBehaviour
    {
        private void Start()
        {
            GameManager.Instance.LoadMenuAndUi(3f);
        }
    }
}
