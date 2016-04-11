using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace QEffect.Effects {

    public class FadeEffect : MonoBehaviour {

        public delegate void FadeEvent ();

        /// <summary>
        /// Called when the AudioObject is finished playing.
        /// </summary>
        public event FadeEvent onFadeFinished;

        /// <summary>
        /// If the screen fade is faded in (example: the screen is black).
        /// </summary>
        [HideInInspector]
        public bool isFadedIn;

        /// <summary>
        /// How long the screen fade will take.
        /// </summary>
        public float fadeTime = 1;

        public CanvasGroup targetCanvasGroup;

        /// <summary>
        /// Fades the fade layer to the given value.
        /// </summary>
        /// <param name="_endValue">The value it will fade to.</param>
        public IEnumerator Fade (float _endValue) {

            targetCanvasGroup.DOFade(_endValue, fadeTime).OnComplete(FadeCompleted);
            yield return new WaitForSeconds(fadeTime);

        }

        /// <summary>
        /// Fades the fade layer to the given value.
        /// </summary>
        /// <param name="_endValue">The value it will fade to.</param>
        /// <param name="_speed">How fast the screen will fade.</param>
        public IEnumerator Fade (float _endValue, float _speed) {

            if (_speed == -1)
                _speed = fadeTime;

            targetCanvasGroup.DOFade(_endValue, _speed).OnComplete(FadeCompleted);
            yield return new WaitForSeconds(_speed);

        }

        /// <summary>
        /// Fades the fade layer to the given value.
        /// </summary>
        /// <param name="_endValue">The value it will fade to.</param>
        /// <param name="_speed">How fast the screen will fade.</param>
        /// <param name="_startValue">which value the canvasGroup starts in.</param>
        public IEnumerator Fade (float _endValue, float _speed, float _startValue) {
            if (_speed == -1)
                _speed = fadeTime;

            targetCanvasGroup.alpha = _startValue;
            targetCanvasGroup.DOFade(_endValue, _speed).OnComplete(FadeCompleted).SetUpdate(true);
            yield return new WaitForSeconds(_speed);

        }

        public IEnumerator TryToFade (float _endValue, float _speed, float _startValue) {

            if(targetCanvasGroup.alpha == _startValue) {

                yield return StartCoroutine(Fade(_endValue, _speed, _startValue));

            } else {

                yield return null;

            }
           

        }

        public void StopFade () {

            targetCanvasGroup.DOKill();

        }

        public void SetFadeLayerValue(float _value) {

            targetCanvasGroup.alpha = _value;

        }

        public float GetFadeLayerValue () {

            return targetCanvasGroup.alpha;

        }

        /// <summary>
        /// Called when the fade tween is finished.
        /// </summary>
        private void FadeCompleted () {

            if(targetCanvasGroup.alpha == 1) {

                isFadedIn = true;

            } else {

                isFadedIn = false;

            }

            if(onFadeFinished != null) {

                onFadeFinished();

            }

        }

    }

}
