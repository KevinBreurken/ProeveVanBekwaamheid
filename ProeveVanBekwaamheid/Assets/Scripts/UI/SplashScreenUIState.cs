using UnityEngine;
using System.Collections;
using BaseFrame.QStates;
using BaseFrame.QEffect;

namespace Base.UI {

    public class SplashScreenUIState : BaseUIState {

        private bool forceNextScreen;
        public float fadeSpeed;
        public float timeTillFadeOut;

        public override void Enter () {

            base.Enter();
            StartCoroutine(EffectManager.Instance.FadeEffect.Fade(0, fadeSpeed, 1));
            StartCoroutine(WaitToFadeOut());

        }

        public override IEnumerator Exit () {
            
            yield return StartCoroutine(EffectManager.Instance.FadeEffect.Fade(1, fadeSpeed));
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
            UIStateSelector.Instance.SetState("MenuUIState");

        }

    }

}