using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProjectTutorial3.Abstracts.Inputs
{
    public interface IPlayerInput 
    {
         float Horizontal { get; }
         float Vertical { get; }
         bool IsJumpButtonDown { get; }
    }

}
