using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Movement
{
    public class Mover : MonoBehaviour
    {

        public void Movement(float horizontal)
        {
            transform.Translate(Vector2.right * horizontal * Time.deltaTime * 12f);
            if (horizontal != 0)
            {
                transform.localScale = new Vector2(Mathf.Sign(horizontal), 1f);
            }
        }
    }
}

