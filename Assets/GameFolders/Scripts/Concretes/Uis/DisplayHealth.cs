using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Uis
{
    public class DisplayHealth : MonoBehaviour
    {
        TextMeshProUGUI healthText;

        private void Awake()
        {
            healthText = GetComponent<TextMeshProUGUI>();
        }

        public void WriteHealth(int currentHealth)
        {
            healthText.text = currentHealth.ToString();
        } 
    }
}
