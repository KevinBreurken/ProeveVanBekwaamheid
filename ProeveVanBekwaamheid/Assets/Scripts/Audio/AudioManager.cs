using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

namespace Base.Audio {

    public class AudioManager : Singleton<AudioManager> {

        public AudioMixerSnapshot defaultSnapshot;
        public AudioMixerSnapshot underwaterSnapshot;

		public AudioMixerGroup musicGroup;
		public AudioMixerGroup effectsGroup;
	
        public void SetUnderwaterMixing (float _time) {

            underwaterSnapshot.TransitionTo(_time);

        }

        public void SetAboveWaterMixing (float _time) {

            defaultSnapshot.TransitionTo(_time);

        }

		public void SetMusic (bool _muted) {
			
		}

		public void SetEffect (bool _muted) {

		}
    }

}