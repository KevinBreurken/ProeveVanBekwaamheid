using UnityEngine;
using System.Collections;
using BaseFrame.QStates;
using DG.Tweening;
using BaseFrame.QAudio;

namespace Base.Game {

    public class InGameState : BaseGameState {

        public SpriteRenderer frontWaterLayer;
        public Camera mainCamera;
        public AnimationCurve cameraEase;
        public float cameraTransitionTime;
        public QAudioObjectHolder ingameMusic;

        private GameManager gameManager;

        void Awake () {

            ingameMusic.CreateAudioObject();
            gameManager = GetComponent<GameManager>();

        }

        public override void Enter () {

            base.Enter();
            StartCoroutine(WaitForFadeIn());

            ingameMusic.GetAudioObject().Play();
            ingameMusic.GetAudioObject().SetVolume(0);
            ingameMusic.GetAudioObject().FadeVolume(0, 1, 50);
       
            mainCamera.transform.DOMoveY(-8, cameraTransitionTime).SetEase(cameraEase).OnComplete(OnCameraPanComplete);

        }

        private void OnCameraPanComplete () {

            gameManager.StartGame();

        }

        private IEnumerator WaitForFadeIn () {

            yield return new WaitForSeconds(1);
            frontWaterLayer.DOColor(new Color(frontWaterLayer.color.r, frontWaterLayer.color.g, frontWaterLayer.color.b, 0), 1);

        }

        public override IEnumerator Exit () {

            gameManager.StopGame();
            frontWaterLayer.DOColor(new Color(frontWaterLayer.color.r, frontWaterLayer.color.g, frontWaterLayer.color.b, 1), 1);
            ingameMusic.GetAudioObject().FadeVolume(1, 0, 1);
            return base.Exit();

        }

        public override void Update () {

            base.Update();

        }

    }

}