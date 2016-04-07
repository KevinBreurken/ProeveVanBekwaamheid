using UnityEngine;
using System.Collections;
using QStates;
using QEffect;

namespace Base.UI {

    public class SplashScreenUIState : BaseUIState {

        public override void Enter () {
            base.Enter();
            
            StartCoroutine("Test");
        }

        IEnumerator Test () {
            EffectManager.Instance.fadeEffect.SetFadeLayerValue(1);
            EffectManager.Instance.fadeEffect.Fade(0);
            yield return null;
           
        }

        public override IEnumerator Exit () {
            return base.Exit();
        }

        public override void Update () {
            base.Update();
        }

    }

}