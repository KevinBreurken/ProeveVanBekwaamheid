using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

namespace Base.Audio {

    public class AudioManager : Singleton<AudioManager> {

        public AudioMixerSnapshot defaultSnapshot;
        public AudioMixerSnapshot underwaterSnapshot;

        public void SetUnderwaterMixing (float _time) {

            underwaterSnapshot.TransitionTo(_time);

        }

        public void SetAboveWaterMixing (float _time) {

            defaultSnapshot.TransitionTo(_time);

        }

    }

}