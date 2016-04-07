﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using QUI.Data;

namespace QUI {

    /// <summary>
    /// UIObject is a interface based object that can be animated by using UIAnimationData.
    /// </summary>
    [AddComponentMenu("BaseFrame")]
    [RequireComponent(typeof(CanvasGroup),typeof(RectTransform),typeof(Image))]
    public class QUIObject : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler {

        /// <summary>
        /// Animation data for the show animation.
        /// </summary>
        public QUIAnimationData showAnimationData;

        /// <summary>
        /// AnimationData for the hide animation.
        /// </summary>
        public QUIAnimationData hideAnimationData;

        /// <summary>
        /// AnimationData for the pointer enter animation.
        /// </summary>
        public QUIAnimationData pointerEnterAnimationData;

        /// <summary>
        /// AnimationData for the pointer exit animation.
        /// </summary>
        public QUIAnimationData pointerExitAnimationData;

        public enum QAUIObjectPointerState {
            InsideObject,
            OutsideObject
        }

        public QAUIObjectPointerState pointerState;

        private CanvasGroup canvasGroup;
        private RectTransform rectTransform;
        protected Image image;

        protected bool isTweening;

        public CanvasGroup GetCanvasGroup () {

            return canvasGroup;

        }

        public virtual void Awake () {

            //Initialize the animation data.
            showAnimationData.Initialize(transform);
            hideAnimationData.Initialize(transform);
            pointerEnterAnimationData.Initialize(transform);
            pointerExitAnimationData.Initialize(transform);

            //Get references
            canvasGroup = GetComponent<CanvasGroup>();
            rectTransform = GetComponent<RectTransform>();
            image = GetComponent<Image>();

        }

        /// <summary>
        /// Called when the mouse pointer enters the UIObject.
        /// </summary>
        public void OnPointerEnter (PointerEventData eventData) {

            pointerState = QAUIObjectPointerState.InsideObject;

            if (!isTweening) {

                StopAllCoroutines();
                StartCoroutine(PlayAnimation(pointerEnterAnimationData));

            }

        }

        /// <summary>
        /// Called when the mouse pointer exits the UIObject.
        /// </summary>
        public void OnPointerExit (PointerEventData eventData) {

            pointerState = QAUIObjectPointerState.OutsideObject;

            if (!isTweening) {

                StopAllCoroutines();
                StartCoroutine(PlayAnimation(pointerExitAnimationData));

            }

        }

        /// <summary>
        /// Hides and disables this UIObject.
        /// </summary>
        public IEnumerator Hide () {

            isTweening = true;

            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;


            yield return StartCoroutine(PlayAnimation(hideAnimationData));

        }

        /// <summary>
        /// Shows and enables this UIObject.
        /// </summary>
        public void Show () {

            isTweening = true;

            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

            StopAllCoroutines();
            StartCoroutine(PlayAnimation(showAnimationData));

        }

        /// <summary>
        /// Plays a animation.
        /// </summary>
        /// <param name="_data">The data that is used for this animation.</param>
        public virtual IEnumerator PlayAnimation (QUIAnimationData _data) {

            //Stop all current DOTween animations.
            canvasGroup.DOKill();
            rectTransform.DOKill();

            //Change graphic if its set.
            if(_data.graphic != null) {

                image.sprite = _data.graphic;

            }

            //Set starting values if they're used.
            if (_data.movementData.usesAnimation && _data.movementData.useStartValue)
                rectTransform.localPosition = _data.movementData.startPosition;
            if (_data.fadeData.usesAnimation && _data.fadeData.useStartValue)
                canvasGroup.alpha = _data.fadeData.startFadeValue;
            if (_data.rotationData.usesAnimation && _data.rotationData.useStartValue)
                rectTransform.eulerAngles = _data.rotationData.startRotation;
            if (_data.colorData.usesAnimation && _data.colorData.useStartValue)
                image.color = _data.colorData.startColorValue;
            if (_data.scaleData.usesAnimation && _data.scaleData.useStartValue)
                rectTransform.localScale = new Vector3(_data.scaleData.startScale, _data.scaleData.startScale, _data.scaleData.startScale);

            yield return new WaitForSeconds(_data.delay);

            //Tween it.
            if (_data.fadeData.usesAnimation)
                StartCoroutine(Fade(_data.fadeData));
            if (_data.movementData.usesAnimation) 
                StartCoroutine(Move(_data.movementData));
            if (_data.rotationData.usesAnimation) 
                StartCoroutine(Rotate(_data.rotationData));
			if (_data.startAudioEffect.usesSoundEffect)
				StartCoroutine(Sound(_data.startAudioEffect));
            if (_data.colorData.usesAnimation)
                StartCoroutine(Color(_data.colorData));
            if(_data.scaleData.usesAnimation)
                StartCoroutine(Scale(_data.scaleData));


            //Wait until the tween is finished.
            yield return new WaitForSeconds(_data.TotalLength);

		
			if (_data.completeAudioEffect.usesSoundEffect)
				StartCoroutine(Sound(_data.completeAudioEffect));

            isTweening = false;

        }

        /// <summary>
        /// Tweens the alpha of this UIObject.
        /// </summary>
        private IEnumerator Fade (QUIFadeAnimationData _data) {

            yield return new WaitForSeconds(_data.delay);
            canvasGroup.DOFade(_data.endFadeValue, _data.animationTime).SetEase(_data.easeType);

        }

        /// <summary>
        /// Tweens the color of this UIObject.
        /// </summary>
        private IEnumerator Color (QUIColorAnimationData _data) {

            yield return new WaitForSeconds(_data.delay);
            image.DOColor(_data.endColorValue, _data.animationTime).SetEase(_data.easeType);

        }


        /// <summary>
        /// Tweens the position of this UIObjet.
        /// </summary>
        private IEnumerator Move (QUIMovementAnimationData _data) {

            yield return new WaitForSeconds(_data.delay);
            rectTransform.DOLocalMove(_data.endPosition, _data.animationTime).SetEase(_data.easeType);

        }

        /// <summary>
        /// Tweens the scale of this UIObjet.
        /// </summary>
        private IEnumerator Scale (QUIScaleAnimationData _data) {

            yield return new WaitForSeconds(_data.delay);
            rectTransform.DOScale(_data.endScale, _data.animationTime).SetEase(_data.easeType);

        }

        /// <summary>
        /// Tweens the position of this UIObjet.
        /// </summary>
        private IEnumerator Rotate (QUIRotationAnimationData _data) {

            yield return new WaitForSeconds(_data.delay);
            rectTransform.DORotate(_data.endRotation, _data.animationTime).SetEase(_data.easeType);

        }

        /// <summary>
        /// Plays a sound effect.
        /// </summary>
		private IEnumerator Sound (QUIAudioAnimationData _data) {

            yield return new WaitForSeconds(_data.soundEffectDelay);
			_data.soundEffect.GetAudioObject().Play();

        }

		// Used for debugging animations.
		void Update () {

			#if UNITY_EDITOR
			if (Input.GetKeyDown(KeyCode.O)) {

				Show();

			}

			if (Input.GetKeyDown(KeyCode.P)) {

				StartCoroutine(Hide());

			}
			#endif

		}

    }

}