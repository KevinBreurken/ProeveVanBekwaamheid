using UnityEngine;
using System.Collections;
using BaseFrame.QUI;
using Base.Audio;

namespace Base.UI {
	
    /// <summary>
    /// Controls the UI elements visible in the options layer.
    /// </summary>
	public class OptionsLayerController : MonoBehaviour {

        /// <summary>
        /// Reference to the mute music toggle.
        /// </summary>
        public QUIToggle muteMusicToggle;
        /// <summary>
        /// Reference to the clear date Button.
        /// </summary>
        public QUIButton clearDataButton;

        // Use this for initialization
        void Awake () {

			muteMusicToggle.onToggleClicked += MuteMusicToggle_onToggleClicked;
			clearDataButton.onClicked += ClearDataButton_onClicked;

		}

		private void MuteMusicToggle_onToggleClicked (bool _state, QUIToggle _toggledObject) {

            AudioListener.pause = _state;

		}

        private void ClearDataButton_onClicked (){

            PlayerPrefs.SetInt("HighScore", 0);

        }

	}

}
