﻿using UnityEngine;
using System.Collections;

namespace BaseFrame.QInput {

	/// <summary>
	/// Input related to using Keyboard as Input Method.
	/// </summary>
    public class KeyboardQInputMethod : BaseQInputMethod {

        [Header("Movement")]
		/// <summary>
		/// Key for left movement.
		/// </summary>
        public KeyCode leftMovementKey = KeyCode.A;
		/// <summary>
		/// Key for right movement.
		/// </summary>
        public KeyCode rightMovementKey = KeyCode.D;
		/// <summary>
		/// Key for up movement.
		/// </summary>
        public KeyCode upMovementKey = KeyCode.W;
		/// <summary>
		/// Key for down movement.
		/// </summary>
        public KeyCode downMovementKey = KeyCode.S;

		/// <summary>
		/// Checks what the horizontal movement input is.
		/// </summary>
		/// <returns>The movement input.</returns>
        public override Vector2 GetMovementInput () {

            Vector2 movementInput = new Vector2(0, 0);

            if (Input.GetKey(leftMovementKey)) { movementInput.x += -1; }
            if (Input.GetKey(rightMovementKey)) {  movementInput.x += 1; }
            if (Input.GetKey(upMovementKey)) { movementInput.y += 1; }
            if (Input.GetKey(downMovementKey)) { movementInput.y -= 1; }

            return movementInput;

        }

    }

}