using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

namespace Base.Audio {

    /// <summary>
    /// Handles audio related functions. 
    /// </summary>
    public class AudioManager : Singleton<AudioManager> {

        /// <summary>
        /// The snapshot that has everything on it's default state.
        /// </summary>
        public AudioMixerSnapshot defaultSnapshot;

        /// <summary>
        /// The snapshot that modifies the audio channels to give a underwater feel.
        /// </summary>
        public AudioMixerSnapshot underwaterSnapshot;

        /// <summary>
        /// Changes the mixing to the underwater sounding mix.
        /// </summary>
        /// <param name="_time">transition time between mixes.</param>
        public void SetUnderwaterMixing (float _time) {

            underwaterSnapshot.TransitionTo(_time);

        }

        /// <summary>
        /// Changes the mixing to the above water(default) sounding mix.
        /// </summary>
        public void SetAboveWaterMixing (float _time) {

            defaultSnapshot.TransitionTo(_time);

        }

    }

}