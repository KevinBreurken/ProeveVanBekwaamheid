using UnityEngine;
using System.Collections;
using BaseFrame.QStates;
using DG.Tweening;

namespace Base.Game {

    public class MenuGameState : BaseGameState {

        public PlayerBehaviour boat;

        [Header("Camera")]
        public Camera mainCamera;
        public AnimationCurve cameraEase;
        public float cameraTransitionTime;

        public override void Enter () {

            base.Enter();

            //Focus the camera to the upper part of the map.
            mainCamera.transform.DOKill();
            mainCamera.transform.DOMoveY(0, cameraTransitionTime).SetEase(cameraEase);

            //Recenter the boat to its center position.
            boat.Recenter();

            Audio.AudioManager.Instance.SetAboveWaterMixing(1);

        }

        public override IEnumerator Exit () {
            return base.Exit();
        }

        public override void Update () {
            base.Update();
        }

    }

}