using UnityEngine;
using System.Collections;
using BaseFrame.QStates;
using DG.Tweening;

namespace Base.Game {

    public class MenuGameState : BaseGameState {

        [Header("Camera")]
        public Camera mainCamera;
        public AnimationCurve cameraEase;
        public float cameraTransitionTime;

        public override void Enter () {
            base.Enter();

            mainCamera.transform.DOKill();
            mainCamera.transform.DOMoveY(0, cameraTransitionTime).SetEase(cameraEase);

        }

        public override IEnumerator Exit () {
            return base.Exit();
        }

        public override void Update () {
            base.Update();
        }

    }

}