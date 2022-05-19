using System.Collections;
using System.Collections.Generic;
using TMPro;
using UdemyProjectTutorial3.Concretes.Managers;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Uis
{
    public class DisplayScore : MonoBehaviour
    {
        TextMeshProUGUI scoreText;

        private void Awake()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            GameManager.Instance.OnScoreChanged += HandleScoreChanged;
            GameManager.Instance.IncreaseScore();
        }
        private void OnDisable()
        {
            GameManager.Instance.OnScoreChanged -= HandleScoreChanged;
        }
        private void HandleScoreChanged(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}
