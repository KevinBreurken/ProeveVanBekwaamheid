using UnityEngine;
using System.Collections;
using BaseFrame.QUI;
using Base.Audio;

namespace Base.UI {
	
	public class OptionsLayerController : MonoBehaviour {

		public QUIToggle muteMusicToggle;
		public QUIToggle muteEffectsToggle;
		public QUIButton clearDataButton;

		// Use this for initialization
		void Awake () {

			muteMusicToggle.onToggleClicked += MuteMusicToggle_onToggleClicked;
			muteEffectsToggle.onToggleClicked += MuteEffectsToggle_onToggleClicked;
			clearDataButton.onClicked += ClearDataButton_onClicked;

		}



		void Start (){

			muteMusicToggle.SetToggleStateRough(( PlayerPrefs.GetInt("MuteMusic",0) == 0 ) ? true : false);
			muteEffectsToggle.SetToggleStateRough(( PlayerPrefs.GetInt("MuteEffects",0) == 0 ) ? true : false);

		}

		void MuteEffectsToggle_onToggleClicked (bool _state, QUIToggle _toggledObject)
		{
			PlayerPrefs.SetInt("MuteEffects",(_state == true) ? 0 : 1);
			AudioManager.Instance.SetEffect(_state);
		}

		void MuteMusicToggle_onToggleClicked (bool _state, QUIToggle _toggledObject)
		{
			PlayerPrefs.SetInt("MuteMusic",(_state == true) ? 0 : 1);
			AudioManager.Instance.SetMusic(_state);
		}

		void ClearDataButton_onClicked ()
		{
			//TODO clear the score data.
		}
		
		// Update is called once per frame
		void Update () {
		
		}

	}

}
