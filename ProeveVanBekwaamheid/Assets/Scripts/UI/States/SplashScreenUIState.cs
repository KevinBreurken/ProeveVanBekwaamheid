using UnityEngine;
using System.Collections;
using BaseFrame.QStates;
using BaseFrame.QEffect;
using DG.Tweening;
using UnityEngine.UI;

namespace Base.UI {

    /// <summary>
    /// UI State that is used for the splash-screen.
    /// </summary>
    public class SplashScreenUIState : BaseUIState {

        /// <summary>
        /// Reference to the main camera.
        /// </summary>
        [Header("Camera")]
        public Camera mainCamera;

        /// <summary>
        /// The starting (y) position of the camera.
        /// </summary>
        public float cameraStartingPosition;

        /// <summary>
        /// The fade-speed of this state.
        /// </summary>
        public float fadeSpeed;

        public Image logo;

        /// <summary>
        /// How long it takes until this state will fade out.
        /// </summary>
        public float timeTillFadeOut;

        private bool forceNextScreen;
        private CanvasGroup stateCanvasGroup;

        void Awake () {

            stateCanvasGroup = GetComponent<CanvasGroup>();

        }

        public override void Enter () {

            base.Enter();

            mainCamera.transform.position = new Vector3(0, cameraStartingPosition, -10);
            mainCamera.transform.DOMoveY(mainCamera.transform.position.y + 2, 10);
            StartCoroutine(EffectManager.Instance.FadeEffect.Fade(0, fadeSpeed, 1));
            StartCoroutine(WaitToFadeOut());
            logo.color = new Color(1, 1, 1, 0);
            logo.DOFade(1, 3);
        }

        public override IEnumerator Exit () {

            stateCanvasGroup.DOFade(0, 0.5f);
            yield return new WaitForSeconds(0.5f);
            base.Exit();

        }

        private IEnumerator WaitToFadeOut () {

            yield return new WaitForSeconds(timeTillFadeOut);
            ForceToNextScreen();

        }

        public override void Update () {

            base.Update();

            if (Input.anyKey) {

                if (!forceNextScreen) {

                    ForceToNextScreen();

                }

            }

        }

        /// <summary>
        /// Forces the splash-screen to fade out.
        /// </summary>
        private void ForceToNextScreen () {

            StopAllCoroutines();
            forceNextScreen = true;

            StartCoroutine(UIStateSelector.Instance.SetState("MenuUIState"));

        }

    }

}