using UnityEngine;
using System.Collections;
using BaseFrame.QStates;
using DG.Tweening;
using BaseFrame.QAudio;
using Base.Manager;

namespace Base.Game {

    /// <summary>
    /// The game state that handles the core game.
    /// </summary>
    public class InGameState : BaseGameState {

        /// <summary>
        /// The water layer that's faded in/out on state enter/exit.
        /// </summary>
        public SpriteRenderer frontWaterLayer;

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

        /// <summary>
        /// The in-game music.
        /// </summary>
        public QAudioObjectHolder ingameMusic;

        /// <summary>
        /// Reference to the game manager.
        /// </summary>
        private GameManager gameManager;

        void Awake () {

            ingameMusic.CreateAudioObject();
            gameManager = GetComponent<GameManager>();

        }

        public override void Enter () {

            base.Enter();
            StartCoroutine(FadeInWaterLayer());

            ingameMusic.GetAudioObject().Play();
            ingameMusic.GetAudioObject().SetVolume(0);
            ingameMusic.GetAudioObject().FadeVolume(0, 1, 50);
       
            mainCamera.transform.DOMoveY(-8, cameraTransitionTime).SetEase(cameraEase).OnComplete(OnCameraPanComplete);

        }

        /// <summary>
        /// Called when the camera animation is finished.
        /// </summary>
        private void OnCameraPanComplete () {

            gameManager.StartGame();

        }

        private IEnumerator FadeInWaterLayer () {

            yield return new WaitForSeconds(1);
            frontWaterLayer.DOColor(new Color(frontWaterLayer.color.r, frontWaterLayer.color.g, frontWaterLayer.color.b, 0), 1);

        }

        public override IEnumerator Exit () {

            frontWaterLayer.DOColor(new Color(frontWaterLayer.color.r, frontWaterLayer.color.g, frontWaterLayer.color.b, 1), 1);
            ingameMusic.GetAudioObject().FadeVolume(1, 0, 1);
            return base.Exit();

        }

    }

}