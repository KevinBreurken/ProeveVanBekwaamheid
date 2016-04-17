using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using BaseFrame.QAudio;

/// <summary>
/// Data classes used by QUI.
/// </summary>
namespace BaseFrame.QUI.Data {

    /// <summary>
    /// The data that is used for animating a QUIObject.
    /// </summary>
    [System.Serializable]
    public struct QUIAnimationData {


        /// <summary>
        /// How long it takes before the animation starts.
        /// </summary>
        public float delay;

        /// <summary>
        /// The total length of this animation.
        /// </summary>
        public float TotalLength;

        /// <summary>
        /// If this data is shown in the Unity Editor.
        /// </summary>
        public bool isShownInEditor;

        /// <summary>
        /// The standard graphic thats used on the QUIObject.
        /// </summary>
        public Sprite defaultGraphic;

        //Transform
        /// <summary>
        /// Data related to move the QUIObject.
        /// </summary>
        public QUIMovementAnimationData movementData;
        /// <summary>
        /// Data related to rotate the QUIObject.
        /// </summary>
        public QUIRotationAnimationData rotationData;
        /// <summary>
        /// Data related to scale the QUIObject.
        /// </summary>
        public QUIScaleAnimationData scaleData;

        //Effect
        /// <summary>
        /// Data related to fade canvasGroup of the QUIObject.
        /// </summary>
        public QUIFadeAnimationData fadeData;
        /// <summary>
        /// Data related to change the color of the QUIObject.
        /// </summary>
        public QUIColorAnimationData colorData;

        //Audio
        /// <summary>
        /// If audioData is shown in the Unity Editor.
        /// </summary>
        public bool isAudioVisibleInEditor;
        /// <summary>
        /// Data related for playing a QAudioObject on animation start.
        /// </summary>
        public QUIAudioAnimationData startAudioEffect;
        /// <summary>
        /// Data related for playing a QAudioObject on animation complete.
        /// </summary>
		public QUIAudioAnimationData completeAudioEffect;
	
        /// <summary>
        /// Initializes this animation. it adds the current position of the object to the start and end position,
        /// creates the audio objects and determines the total length of this animation.
        /// </summary>
        /// <param name="_QUIObject">the QUIObject's transform that holds this QUIAnimationData.</param>
        public void Initialize (Transform _QUIObject) {
			
			movementData.AddObjectPosition(_QUIObject.localPosition);
			CreateSoundObject(_QUIObject,startAudioEffect);
			CreateSoundObject(_QUIObject,completeAudioEffect);
            SetTotalAnimationLength();

        }

        /// <summary>
        /// Plays the Sound effect if it has one.
        /// </summary>
		public void PlaySound (QUIAudioAnimationData _data) {

			if (_data.soundEffect.audioObject != null) { _data.soundEffect.audioObject.Play(); }

        }

		/// <summary>
		/// Creates a QAudioObject thats used by this QUIObject.
		/// </summary>
		/// <param name="_parent">The parent of the new made QAudioObject.</param>
		/// <param name="_data">The AnimationData for the AudioObject.</param>
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

            //Get the length of each animation being used.
            if (fadeData.usesAnimation) timeTotal.Add(fadeData.animationTime + fadeData.delay);
			if (movementData.usesAnimation) timeTotal.Add(movementData.animationTime + movementData.delay);
            if (rotationData.usesAnimation) timeTotal.Add(rotationData.animationTime + rotationData.delay);
            if (colorData.usesAnimation) timeTotal.Add(colorData.animationTime + colorData.delay);
            if (scaleData.usesAnimation) timeTotal.Add(scaleData.animationTime + scaleData.delay);

            //get the highest value of the ones being used.
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

    /// <summary>
    /// Data Used for QAudio related Animation Effects.
    /// </summary>
	[System.Serializable]
	public class QUIAudioAnimationData {

        /// <summary>
        /// If this data is visible in the editor.
        /// </summary>
        public bool isVisibleInEditor;

		/// <summary>
		/// If this animation uses a sound effect.
		/// </summary>
		public bool usesSoundEffect;

		/// <summary>
		/// The prefab of the sound effect.
		/// </summary>
		public QAudioObjectHolder soundEffect;

		/// <summary>
		/// How long it takes before the sound effect starts.
		/// </summary>
		public float soundEffectDelay;

	}

    /// <summary>
    /// Data Used for QUI Movement Animations.
    /// </summary>
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
		/// <param name="_localPosition">Local position of the QUIObject.</param>
		public void AddObjectPosition (Vector3 _localPosition) {

			startPosition += new Vector2(_localPosition.x, _localPosition.y);
			endPosition += new Vector2(_localPosition.x, _localPosition.y);

		}

	}

    /// <summary>
    /// Data Used for QUI Scale Animations.
    /// </summary>
    [System.Serializable]
    public class QUIScaleAnimationData : QUIBaseAnimationData {

        /// <summary>
        /// The starting scale of the QUIObject. (default scale is 1.0)
        /// </summary>
		public float startScale;

        /// <summary>
        /// The end scale of the QUIObject.
        /// </summary>
		public float endScale;

	}

    /// <summary>
    /// Data Used for QUI Fade Animations.
    /// </summary>
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
    /// Data Used for QUI Color Animations.
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
    /// Data Used for QUI Rotation Animations.
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

    /// <summary>
    /// BaseClass for Data Used for QUI Animations.
    /// </summary>
    [System.Serializable]
	public class QUIBaseAnimationData {
		
        /// <summary>
        /// If this is data is visible in the editor.
        /// </summary>
		public bool isVisibleInEditor;

        /// <summary>
        /// If the animation uses a starting value.
        /// This means that if this is true, the animation will begin at that value. 
        /// else it'll use its current value.
        /// </summary>
		public bool useStartValue;

        /// <summary>
        /// If this animation is being used.
        /// </summary>
		public bool usesAnimation;

        /// <summary>
        /// The easing type being used by this animation.
        /// </summary>
		public Ease easeType;

        /// <summary>
        /// The length of this animation.
        /// </summary>
		public float animationTime;

        /// <summary>
        /// How long it takes before this animation is being called.
        /// </summary>
		public float delay;

	}

}
	