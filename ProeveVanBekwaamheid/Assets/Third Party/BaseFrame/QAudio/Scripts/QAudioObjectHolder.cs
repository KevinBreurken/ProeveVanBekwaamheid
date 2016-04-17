using UnityEngine;
using System.Collections;

namespace BaseFrame.QAudio {

    /// <summary>
    /// A holder that contains the prefab and a reference
    /// to the AudioObject.
    /// </summary>
    [System.Serializable]
    public struct QAudioObjectHolder {
        /// <summary>
        /// The prefab of the QAudioObject.
        /// </summary>
        public GameObject objectPrefab;

        /// <summary>
        /// The audioObject of the instantiated prefab.
        /// </summary>
        [HideInInspector]
        public QAudioObject audioObject;

        /// <summary>
        /// Creates the AudioObject.
        /// </summary>
        public void CreateAudioObject () {

            if (objectPrefab != null) {

                audioObject = QAudioObject.CreateAudioInstance(objectPrefab);

            } else {

                Debug.LogWarning("Audio Prefab not set");

            }

        }

        /// <summary>
        /// Returns the AudioObject instance.
        /// </summary>
        /// <returns>The AudioObjectInstance.</returns>
        public QAudioObject GetAudioObject () {

            if (audioObject != null) {

                return audioObject;

            } else {

                Debug.LogError("AudioObject not created, is CreateAudiObject being used?");
                return null;

            }
                
        }

    }

}