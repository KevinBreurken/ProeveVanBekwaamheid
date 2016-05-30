using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// QInput: Part of BaseFrame that handles Input.
/// </summary>
namespace BaseFrame.QInput {

    /// <summary>
    /// Handles everything input related.
    /// Input method is changed by calling SetInputMethod().
    /// </summary>
    public class QInputManager : MonoBehaviour {

        private static QInputManager instance = null;
        /// <summary>
        /// Static reference of the InputManager.
        /// </summary>
        public static QInputManager Instance {

            get {

                if (instance == null) {

                    instance = FindObjectOfType(typeof(QInputManager)) as QInputManager;

                }

                return instance;

            }

        }

		/// <summary>
		/// Input change event.
		/// </summary>
		public delegate void InputChangeEvent (BaseQInputMethod _changedMethod);

        /// <summary>
        /// Called when the input method is changed.
        /// </summary>
		public event InputChangeEvent onInputChanged;

        /// <summary>
        /// List of all possible input methods.
        /// </summary>
        public List<BaseQInputMethod> inputMethods = new List<BaseQInputMethod>();

        /// <summary>
        /// The inputMethod that will be used by default.
        /// </summary>
        public BaseQInputMethod startInputMethod;

        private BaseQInputMethod currentlyUsedInputMethod;

        void Awake () {

            SetInputMethod(startInputMethod.gameObject.name);

        }

        /// <summary>
        /// Sets the input method.
        /// </summary>
        /// <param name="_inputName">Name of the InputMethod.</param>
        public void SetInputMethod (string _inputName) {

            for (int i = 0; i < inputMethods.Count; i++) {

                if(inputMethods[i].name == _inputName) {

                    SetInputMethod(inputMethods[i].GetComponent<BaseQInputMethod>());
                    break;

                }

            }

        }

        /// <summary>
        /// Sets the input method.
        /// </summary>
		/// <param name="_inputMethod">The input method.</param>
        public void SetInputMethod (BaseQInputMethod _inputMethod) {

           currentlyUsedInputMethod = _inputMethod;

           if (onInputChanged != null)
           onInputChanged(currentlyUsedInputMethod);

        }

        /// <summary>
        /// Returns the currently used Input Method.
        /// </summary>
		public BaseQInputMethod GetCurrentInputMethod () {
			
			return currentlyUsedInputMethod;

		}


    }

}
