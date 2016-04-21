using UnityEngine;
using System.Collections;
using BaseFrame.QStates;
using DG.Tweening;

namespace Base.Game {

    public class InGameState : BaseGameState {

        public SpriteRenderer frontWaterLayer;
        public Camera mainCamera;
        public AnimationCurve cameraEase;
        public float cameraTransitionTime;

        public override void Enter () {

            base.Enter();
            StartCoroutine(WaitForFadeIn());
            mainCamera.transform.DOMoveY(-8, cameraTransitionTime).SetEase(cameraEase);

        }

        private IEnumerator WaitForFadeIn () {

            yield return new WaitForSeconds(1);
            frontWaterLayer.DOColor(new Color(frontWaterLayer.color.r, frontWaterLayer.color.g, frontWaterLayer.color.b, 0), 1);

        }

        public override IEnumerator Exit () {

            frontWaterLayer.DOColor(new Color(frontWaterLayer.color.r, frontWaterLayer.color.g, frontWaterLayer.color.b, 1), 1);
            return base.Exit();

        }

        public override void Update () {

            base.Update();

        }

    }

}