using UnityEngine;
using System.Collections;
using QStates;
using QEffect;

namespace Base.UI {

    public class SplashScreenUIState : BaseUIState {

        private bool forceNextScreen;
        public float fadeSpeed;
        public float timeTillFadeOut;

        public override void Enter () {

            base.Enter();
            StartCoroutine(EffectManager.Instance.fadeEffect.Fade(0, fadeSpeed, 1));
            StartCoroutine(WaitToFadeOut());

        }

        public override IEnumerator Exit () {
            
            yield return StartCoroutine(EffectManager.Instance.fadeEffect.Fade(1, fadeSpeed));
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

            EffectManager.Instance.fadeEffect.StopFade();
            UIStateSelector.Instance.SetState("MenuUIState");

        }

    }

}