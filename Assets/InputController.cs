using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class InputController
    {
        private InputData inputData;

        public InputController(InputData inputData)
        {
            this.inputData = inputData;
        }

        public void Update()
        {
            inputData.horizontal = Input.GetAxis(InputKeyNames.horizontal);
            inputData.vertical = Input.GetAxis(InputKeyNames.vertical);

            inputData.keyLeftShiftDown = Input.GetKeyDown(KeyCode.LeftShift);
            inputData.keyLeftShiftUp = Input.GetKeyUp(KeyCode.LeftShift);

            inputData.fireButtonDown = Input.GetButtonDown(InputKeyNames.fire);
        }

    }
}
