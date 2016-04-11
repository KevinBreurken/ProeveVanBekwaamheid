using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using QAudio;

namespace QUI.Data {

    /// <summary>
    /// The data that is used for animating a UI Element.
    /// </summary>
    [System.Serializable]
    public struct QUIAnimationData {

        //Overall Variables
        /// <summary>
        /// How long it takes before the animation starts.
        /// </summary>
        public float delay;

        /// <summary>
        /// The total length of this animation.
        /// </summary>
        public float TotalLength;

        public bool isShownInEditor;
        public bool isAudioShownInEditor;

        public Sprite graphic;

        public QUIMovementAnimationData movementData;
        public QUIRotationAnimationData rotationData;
        public QUIScaleAnimationData scaleData;

        public QUIFadeAnimationData fadeData;
        public QUIColorAnimationData colorData;

        public QUIAudioAnimationData startAudioEffect;
		public QUIAudioAnimationData completeAudioEffect;
	

        /// <summary>
        /// Initializes this animation. it adds the current position of the object to the start and end position,
        /// creates the audio objects and determines the total length of this animation.
        /// </summary>
        /// <param name="_parent"></param>
        public void Initialize (Transform _parent) {
			
			movementData.AddObjectPosition(_parent.localPosition);
			CreateSoundObject(_parent,startAudioEffect);
			CreateSoundObject(_parent,completeAudioEffect);
            SetTotalAnimationLength();

        }

        /// <summary>
        /// Plays the Sound effect if it has one.
        /// </summary>
		public void PlaySound (QUIAudioAnimationData _data) {

			if (_data.soundEffect.audioObject != null) {

				_data.soundEffect.audioObject.Play();

            }

        }

		/// <summary>
		/// Creates the sound object.
		/// </summary>
		/// <param name="_parent">Parent.</param>
		/// <param name="_data">Data.</param>
		private void CreateSoundObject (Transform _parent,QUIAudioAnimationData _data) {

            if (_data.soundEffect.objectPrefab != null) {

                _data.soundEffect.CreateAudioObject();
                QAudioObject obj = _data.soundEffect.audioObject;
                _data.soundEffect.audioObject = obj;
				_data.soundEffect.audioObject.SetOnPosition(_parent);

            }

        }

		/// <summary>
		/// Checks how long the animation is.
		/// </summary>
        private void SetTotalAnimationLength () {

            List<float> timeTotal = new List<float>();

            //Get the length of the animations being used.
            if (fadeData.usesAnimation)
                timeTotal.Add(fadeData.animationTime + fadeData.delay);
			if (movementData.usesAnimation)
				timeTotal.Add(movementData.animationTime + movementData.delay);
            if (rotationData.usesAnimation)
                timeTotal.Add(rotationData.animationTime + rotationData.delay);
            if (colorData.usesAnimation)
                timeTotal.Add(colorData.animationTime + colorData.delay);
            if (scaleData.usesAnimation)
                timeTotal.Add(scaleData.animationTime + scaleData.delay);

            //get the highest value.
            float highest = 0;
            for (int i = 0; i < timeTotal.Count; i++) {

                if (timeTotal[i] > highest) {
                    //Set the highest value.
                    highest = timeTotal[i];

                }

            }

            TotalLength = highest;

        }

    }

	[System.Serializable]
	public class QUIAudioAnimationData {

		/// <summary>
		/// If this animation uses a sound effect.
		/// </summary>
		public bool usesSoundEffect;

		/// <summary>
		/// The prefab of the sound effect.
		/// </summary>
		public AudioObjectHolder soundEffect;

		/// <summary>
		/// How long it takes before the sound effect starts.
		/// </summary>
		public float soundEffectDelay;

	}

    [System.Serializable]
    public class QUIMovementAnimationData : QUIBaseAnimationData{

		/// <summary>
		/// Where this move animation starts.
		/// </summary>
		public Vector2 startPosition;

		/// <summary>
		/// Where this move animation ends.
		/// </summary>
		public Vector2 endPosition;


		/// <summary>
		/// Adds the current local position of the Object to the movement tweens.
		/// </summary>
		/// <param name="_localPosition">Local position.</param>
		public void AddObjectPosition (Vector3 _localPosition) {

			startPosition += new Vector2(_localPosition.x, _localPosition.y);
			endPosition += new Vector2(_localPosition.x, _localPosition.y);

		}

	}

    [System.Serializable]
    public class QUIScaleAnimationData : QUIBaseAnimationData {

		public float startScale;

		public float endScale;


	}

    [System.Serializable]
    public class QUIFadeAnimationData : QUIBaseAnimationData{

		/// <summary>
		/// The fade value this animation starts with.
		/// </summary>
		public float startFadeValue;

		/// <summary>
		/// The fade value this animation ends with.
		/// </summary>
		public float endFadeValue;

	}

    /// <summary>
    /// Handles all color animation data.
    /// </summary>
    [System.Serializable]
    public class QUIColorAnimationData : QUIBaseAnimationData{

		/// <summary>
		/// The fade value this animation starts with.
		/// </summary>
		public Color startColorValue;

		/// <summary>
		/// The fade value this animation ends with.
		/// </summary>
		public Color endColorValue;

	}

    /// <summary>
    /// Handles all rotation animation data.
    /// </summary>
    [System.Serializable]
    public class QUIRotationAnimationData : QUIBaseAnimationData{

		/// <summary>
		/// The rotation value this animation starts with.
		/// </summary>
		public Vector3 startRotation;

		/// <summary>
		/// The rotation value this animation ends with.
		/// </summary>
		public Vector3 endRotation;

	}

    [System.Serializable]
	public class QUIBaseAnimationData {
		
		public bool isVisibleInEditor;
		public bool useStartValue;
		public bool usesAnimation;
		public Ease easeType;
		public float animationTime;
		public float delay;

	}

}
	