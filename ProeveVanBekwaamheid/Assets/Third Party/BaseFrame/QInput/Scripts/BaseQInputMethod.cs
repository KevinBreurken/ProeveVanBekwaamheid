using UnityEngine;
using System.Collections;

namespace QInput {

    /// <summary>
    /// BaseClass for InputMethod. InputMethod is used by the InputManager.
    /// </summary>
    public class BaseQInputMethod : MonoBehaviour {

        public delegate void InputEvent ();

        /// <summary>
        /// Called when the AudioObject is finished playing.
        /// </summary>
        public event InputEvent onJumpPressed;

        /// <summary>
        /// Checks what the horizontal movement input is.
        /// </summary>
		public virtual Vector2 GetMovementInput () {

			return new Vector2(0,0);

        }

        public virtual void Update () { }

        /// <summary>
        /// Fires the jump event.
        /// </summary>
        public void FireJumpEvent () {

            if(onJumpPressed != null) {

                onJumpPressed();

            }

        }

    }

}