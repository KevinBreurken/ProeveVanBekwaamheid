using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using QUI.Data;

namespace QUI {

    [RequireComponent(typeof(Toggle), typeof(Image))]
    public class QUIToggle : QUIObject {

        public delegate void ToggleEvent (bool _state,QUIToggle _toggledObject);

        /// <summary>
        /// Called when the AudioObject is finished playing.
        /// </summary>
        public event ToggleEvent onToggleClicked;

        /// <summary>
        /// AnimationData for the pointer exit animation.
        /// </summary>
        public QUIAnimationData pointerClickAnimationData;

        private Button Button;
        private Toggle Toggle;
        public Sprite normalSprite;

        public override void Awake () {

            base.Awake();

            pointerClickAnimationData.Initialize(transform);
            normalSprite = image.sprite;
            Toggle = GetComponent<Toggle>();
            Toggle.onValueChanged.AddListener((value) => OnToggleToggled(value));

        }

        private void OnToggleToggled (bool _state) {

            if (!isTweening) {

                isTweening = true;
                StopAllCoroutines();
                StartCoroutine(PlayClickAnimation(pointerClickAnimationData));

                if (onToggleClicked != null) {

                    onToggleClicked(Toggle.isOn,this);

                }

            }

        }

        public IEnumerator PlayClickAnimation (QUIAnimationData _data) {

            StartCoroutine(PlayAnimation(_data));
            yield return new WaitForSeconds(0.2f);
            ReturnGraphic();


        }

        public void SetToggleStateRough(bool _state) {

            Toggle.onValueChanged.RemoveAllListeners();
            Toggle.isOn = _state;
            Toggle.onValueChanged.AddListener((value) => OnToggleToggled(value));

        }

        public void SetInteractable(bool _state) {
            Toggle.interactable = _state;
        }

        private void ReturnGraphic () {

            if (pointerState == QAUIObjectPointerState.InsideObject) {

                if (pointerEnterAnimationData.graphic != null) {

                    image.sprite = pointerEnterAnimationData.graphic;

                } else {

                    image.sprite = normalSprite;

                }

            } else {

                if (pointerExitAnimationData.graphic != null) {

                    image.sprite = pointerExitAnimationData.graphic;

                } else {

                    image.sprite = normalSprite;

                }

            }

        }

        // Used for debugging animations.
        void Update () {

#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.O)) {

                StartCoroutine(Show());

            }

            if (Input.GetKeyDown(KeyCode.P)) {

                StartCoroutine(Hide());

            }
#endif

        }

    }

}
