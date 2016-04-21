using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using BaseFrame.QUI.Data;

namespace BaseFrame.QUI {

    /// <summary>
    /// QUIToggle is a interface based object that can receive player pointer input with a off and on state.
    /// </summary>
    [RequireComponent(typeof(Toggle), typeof(Graphic))]
    public class QUIToggle : QUIObject {

		/// <summary>
		/// Used for toggle events.
		/// </summary>
        public delegate void ToggleEvent (bool _state, QUIToggle _toggledObject);

        /// <summary>
        /// Called when the AudioObject is finished playing.
        /// </summary>
        public event ToggleEvent onToggleClicked;

        /// <summary>
        /// AnimationData for the pointer exit animation.
        /// </summary>
        public QUIAnimationData pointerClickAnimationData;

        /// <summary>
        /// The graphic that will be used as default graphic by this QUIToggle.
        /// </summary>
        public Sprite normalSprite;

        /// <summary>
        /// Reference to the Button component of this QUIButton.
        /// </summary>
        private Toggle Toggle;

		/// <summary>
		/// Called first by Unity3D.
		/// </summary>
        public override void Awake () {

            base.Awake();

            pointerClickAnimationData.Initialize(transform);
            normalSprite = graphic.GetComponent<Image>().sprite;
            Toggle = GetComponent<Toggle>();
            Toggle.onValueChanged.AddListener((value) => OnToggleToggled(value));

        }

        /// <summary>
        /// Called when the QUIToggle is clicked.
        /// </summary>
        /// <param name="_state">The state of the toggle</param>
        private void OnToggleToggled (bool _state) {

            if (!isAnimating) {

                isAnimating = true;
                StopAllCoroutines();
                StartCoroutine(PlayClickAnimation());

                if (onToggleClicked != null) {

                    onToggleClicked(Toggle.isOn, this);

                }

            }

        }

        /// <summary>
        /// Plays the click animation.
        /// </summary>
        public IEnumerator PlayClickAnimation () {

            StartCoroutine(PlayAnimation(pointerClickAnimationData));
            yield return new WaitForSeconds(0.2f);
            ReturnGraphic();

        }

        /// <summary>
        /// Changes the toggle state without playing the click animation.
        /// </summary>
        /// <param name="_state">The new state.</param>
        public void SetToggleStateRough (bool _state) {

            Toggle.onValueChanged.RemoveAllListeners();
            Toggle.isOn = _state;
            Toggle.onValueChanged.AddListener((value) => OnToggleToggled(value));

        }

        /// <summary>
        /// Sets the interactable state of this QUIToggle.
        /// </summary>
        /// <param name="_state">The interactable state of this QUIToggle.</param>
        public override void SetInteractable (bool _state) {

            Toggle.interactable = _state;

        }

        /// <summary>
        /// Resets the graphic back to its normal graphic.
        /// </summary>
        private void ReturnGraphic () {

            if (currentPointerState == QAUIObjectPointerState.InsideObject) {

                if (pointerEnterAnimationData.defaultGraphic != null) {

                    graphic.GetComponent<Image>().sprite = pointerEnterAnimationData.defaultGraphic;

                } else {

                    graphic.GetComponent<Image>().sprite = normalSprite;

                }

            } else {

                if (pointerExitAnimationData.defaultGraphic != null) {

                    graphic.GetComponent<Image>().sprite = pointerExitAnimationData.defaultGraphic;

                } else {

                    graphic.GetComponent<Image>().sprite = normalSprite;

                }

            }

        }

    }

}
