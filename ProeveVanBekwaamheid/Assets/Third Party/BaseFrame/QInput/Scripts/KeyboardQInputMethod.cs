using UnityEngine;
using System.Collections;

namespace QInput {


    public class KeyboardQInputMethod : BaseQInputMethod {

        [Header("Movement")]
        public KeyCode leftMovementKey = KeyCode.A;
        public KeyCode rightMovementKey = KeyCode.D;
        public KeyCode upMovementKey = KeyCode.W;
        public KeyCode downMovementKey = KeyCode.S;

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