using UnityEngine;
using System.Collections;
using BaseFrame.QStates;
using DG.Tweening;

namespace Base.Game {

    /// <summary>
    /// The game state that handles the menu.
    /// </summary>
    public class MenuGameState : BaseGameState {

        /// <summary>
        /// Reference to the boat.
        /// </summary>
        public PlayerBehaviour boat;

        /// <summary>
        /// Reference to the main camera.
        /// </summary>
        [Header("Camera")]
        public Camera mainCamera;

        /// <summary>
        /// Easing for the camera animation.
        /// </summary>
        public AnimationCurve cameraEase;

        /// <summary>
        /// How long the camera transition is.
        /// </summary>
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

    }

}