using UnityEngine;
using System.Collections;
using BaseFrame.QStates;
using BaseFrame.QEffect;
using DG.Tweening;

namespace Base.UI {

    public class SplashScreenUIState : BaseUIState {

        public Camera mainCamera;
        public float cameraStartingPosition;
        public float fadeSpeed;
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

        private void ForceToNextScreen () {

            StopAllCoroutines();
            forceNextScreen = true;

            EffectManager.Instance.FadeEffect.StopFade();
            StartCoroutine(UIStateSelector.Instance.SetState("MenuUIState"));

        }

    }

}