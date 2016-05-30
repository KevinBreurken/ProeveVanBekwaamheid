using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using BaseFrame.QUI.Data;

namespace BaseFrame.QUI {

    /// <summary>
    /// UIButton is a interface based object that can receive player pointer input.
    /// </summary>
    [RequireComponent(typeof(Button),typeof(Graphic))]
    public class QUIButton : QUIObject {

		/// <summary>
		/// Used for button events.
		/// </summary>
        public delegate void ButtonEvent ();

        /// <summary>
        /// Called when the QUIButton is clicked.
        /// </summary>
        public event ButtonEvent onClicked;

        /// <summary>
        /// AnimationData for the pointer click animation.
        /// </summary>
        public QUIAnimationData pointerClickAnimationData;

        /// <summary>
        /// The graphic that will be used as default graphic by this QUIButton.
        /// </summary>
        public Sprite normalSprite;

        /// <summary>
        /// Reference to the Button component of this QUIButton.
        /// </summary>
        private Button Button;

		/// <summary>
		/// Called first by Unity3D.
		/// </summary>
        public override void Awake () {

            base.Awake();

            pointerClickAnimationData.Initialize(transform);

            Button = GetComponent<Button>();
            Button.onClick.AddListener(() => OnButtonClicked());

        }

        /// <summary>
        /// Called when the QUIButton is clicked.
        /// </summary>
        private void OnButtonClicked () {

            if (!isAnimating) {

                StopAllCoroutines();
                StartCoroutine(PlayClickAnimation());

                if (onClicked != null) {

                    onClicked();

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
        /// Resets the graphic back to its normal graphic.
        /// </summary>
        private void ReturnGraphic () {

            if(currentPointerState == QAUIObjectPointerState.InsideObject) {

                if (pointerEnterAnimationData.defaultGraphic != null) {

                    graphic.GetComponent<Image>().sprite = pointerEnterAnimationData.defaultGraphic;

                } else {

                    //Debug.LogError("[QAUI] Warning: Button's enter state has no graphic selected in its enter state. Set a graphic in the pointer enter animation.");

                }

            } else {

                if (pointerExitAnimationData.defaultGraphic != null) {

                    graphic.GetComponent<Image>().sprite = pointerExitAnimationData.defaultGraphic;

                } else {

                    Debug.LogError("[QAUI] Warning: Button's exit state has no graphic selected in its exit state. Set a graphic in the pointer exit animation.");

                }

            }
         
        }

        /// <summary>
        /// Sets the interactable state of this QUIButton.
        /// </summary>
        /// <param name="_state">The interactable state of this QUIButton.</param>
        public override void SetInteractable (bool _state) {

            if(isActiveAndEnabled)
            Button.interactable = _state;

        }

    }

}
