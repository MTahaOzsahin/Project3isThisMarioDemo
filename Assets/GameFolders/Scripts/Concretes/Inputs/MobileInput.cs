using System.Collections;
using System.Collections.Generic;
using UdemyProjectTutorial3.Abstracts.Inputs;
using UnityEngine;

namespace UdemyProjectTutorial3.Concretes.Inputs
{
    public class MobileInput : IPlayerInput
    {
        public float Horizontal => Input.GetAxis("Horizontal");
        public float Vertical => Input.GetAxis("Vertical");
        public bool IsJumpButtonDown => Input.GetButtonDown("Jump");
    }
}

