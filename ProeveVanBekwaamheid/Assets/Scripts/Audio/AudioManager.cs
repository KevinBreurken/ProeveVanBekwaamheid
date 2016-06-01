using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using DG.Tweening;

/// <summary>
/// Contains audio related classes.
/// </summary>
namespace Base.Audio {

    /// <summary>
    /// Handles Audio related effects.
    /// </summary>
    public class AudioManager : Singleton<AudioManager> {

        /// <summary>
        /// The default snapshot with no modifications.
        /// </summary>
        public AudioMixerSnapshot defaultSnapshot;

        /// <summary>
        /// The underwater snapshot that has the dampened sound.
        /// </summary>
        public AudioMixerSnapshot underwaterSnapshot;

        /// <summary>
        /// Reference to the outside ambient sound
        /// </summary>
        private AudioSource outsideSound;

        public AudioSource outsideSoundWebGL;

        /// <summary>
        /// If the game is player in WebGL
        /// </summary>
        private bool isWebGL = false;

        void Awake () {

            outsideSound = transform.FindChild("Ambience_AboveWater").GetComponent<AudioSource>();

            #if UNITY_WEBGL
            isWebGL = true;
            #endif

        }

        /// <summary>
        /// Sets the AudioMixer to the underwater snapshot.
        /// </summary>
        /// <param name="_time">How long it takes to fade to this snapshot.</param>
        public void SetUnderwaterMixing (float _time) {

            if (!isWebGL) {

                underwaterSnapshot.TransitionTo(_time);

            } else {

                outsideSound.DOFade(0, 1);
                outsideSoundWebGL.DOFade(1, 1);

            }

        }

        /// <summary>
        /// Sets the AudioMixer to the above water snapshot.
        /// </summary>
        /// <param name="_time">How long it takes to fade to this snapshot.</param>
        public void SetAboveWaterMixing (float _time) {

            if (!isWebGL) {

                defaultSnapshot.TransitionTo(_time);

            } else {

                outsideSound.DOFade(1, 1);
                outsideSoundWebGL.DOFade(0, 1);

            }
           
        }
			
    }

}