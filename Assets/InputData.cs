using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class InputData
    {
        public float horizontal;
        public float vertical;
        public bool keyLeftShiftDown;
        public bool keyLeftShiftUp;
        public bool fireButtonDown;

        public InputData()
        {
            horizontal = 0;
            vertical = 0;
            keyLeftShiftDown = false;
            keyLeftShiftUp = false;
            fireButtonDown = false;
        }
    }
}
