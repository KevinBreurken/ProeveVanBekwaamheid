using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using DG.Tweening;

namespace Base.Audio {

    public class AudioManager : Singleton<AudioManager> {

        public AudioMixerSnapshot defaultSnapshot;
        public AudioMixerSnapshot underwaterSnapshot;
        private AudioSource outsideSound;

        private bool isWebGL = false;

        void Awake () {
            outsideSound = transform.FindChild("Ambience_AboveWater").GetComponent<AudioSource>();
            #if UNITY_WEBGL
            isWebGL = true;
            #endif
        }

        public void SetUnderwaterMixing (float _time) {

            if (!isWebGL)
                underwaterSnapshot.TransitionTo(_time);
            else
                outsideSound.DOFade(0, 1);
        }

        public void SetAboveWaterMixing (float _time) {

            if (!isWebGL)
                defaultSnapshot.TransitionTo(_time);
            else
                outsideSound.DOFade(1, 1);
        }
			
    }

}