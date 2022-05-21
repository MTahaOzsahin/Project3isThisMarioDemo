using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UdemyProjectTutorial3.Concretes.Combats;
using UdemyProjectTutorial3.Concretes.Controllers.CheckPoints;
using UdemyProjectTutorial3.Concretes.Controllers.PlayerControllers;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Managers
{
    public class CheckpointManager : MonoBehaviour
    {
        CheckpointsController[] checkpointsControllers;

        Health health;

        private void Awake()
        {
            checkpointsControllers = GetComponentsInChildren<CheckpointsController>();
            health = FindObjectOfType<PlayerController>().GetComponent<Health>(); // B�ylelikle sadece playerin ta��d��� health componentini alm�� olduk.
        }

        private void Start()
        {
            health.OnHealthChanged += HandleHealthChanged;
        }

        private void HandleHealthChanged(int currentHealth, int maxHealth)
        {
                                                                //Buradaki x noktalar� temsil ediyor.
            health.transform.position = checkpointsControllers.LastOrDefault(x => x.IsPassed).transform.position; //Varsa son  ge�ti�i de�eri d�n�yor Lastor
        }
    }
}
