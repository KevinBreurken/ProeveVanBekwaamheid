using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using QUI.Data;

namespace QUI {

    [RequireComponent(typeof(Button),typeof(Image))]
    public class QUIButton : QUIObject {

        public delegate void ButtonEvent ();

        /// <summary>
        /// Called when the AudioObject is finished playing.
        /// </summary>
        public event ButtonEvent onClicked;

        /// <summary>
        /// AnimationData for the pointer exit animation.
        /// </summary>
        public QUIAnimationData pointerClickAnimationData;

        private Button Button;
        public Sprite normalSprite;

        public override void Awake () {

            base.Awake();

            pointerClickAnimationData.Initialize(transform);

            Button = GetComponent<Button>();
            Button.onClick.AddListener(() => OnButtonClicked());

        }

        private void OnButtonClicked () {

            if (!isTweening) {

                StopAllCoroutines();
                StartCoroutine(PlayClickAnimation(pointerClickAnimationData));

                if (onClicked != null) {

                    onClicked();

                }

            }

        }

        public IEnumerator PlayClickAnimation (QUIAnimationData _data) {
			
            StartCoroutine(PlayAnimation(_data));
            yield return new WaitForSeconds(0.2f);
            ReturnGraphic();
           

        }

        private void ReturnGraphic () {

            if(pointerState == QAUIObjectPointerState.InsideObject) {

                if (pointerEnterAnimationData.graphic != null) {

                    image.sprite = pointerEnterAnimationData.graphic;

                } else {

                    Debug.LogError("[QAUI] Warning: Button's enter state has no graphic selected in its enter state. Set a graphic in the pointer enter animation.");

                }

            } else {

                if (pointerExitAnimationData.graphic != null) {

                    image.sprite = pointerExitAnimationData.graphic;

                } else {

                    Debug.LogError("[QAUI] Warning: Button's exit state has no graphic selected in its exit state. Set a graphic in the pointer exit animation.");

                }

            }
         
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
