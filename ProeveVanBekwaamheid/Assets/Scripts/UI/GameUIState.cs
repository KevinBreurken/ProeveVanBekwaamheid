using UnityEngine;
using System.Collections;
using BaseFrame.QStates;
using BaseFrame.QUI;
using BaseFrame.QEffect;
using DG.Tweening;

namespace Base.UI {

    public class GameUIState : BaseUIState {

		public QUIButton pauseButton;
        public ScoreDisplay scoreDisplay;
        public PauseOverlay pauseOverlay;
        private CanvasGroup canvasGroup;

		void Awake () {

            canvasGroup = GetComponent<CanvasGroup>();
			pauseButton.onClicked += PauseButton_onClicked;

		}

        public override void Enter () {

            base.Enter();
            canvasGroup.alpha = 0;
            canvasGroup.DOFade(1, 0.3f);
            scoreDisplay.Hide(true);

        }

        void PauseButton_onClicked ()
        {
            pauseOverlay.OpenOverlay();
        }

        public override IEnumerator Exit () {

            canvasGroup.DOFade(0, 0.3f);
            yield return new WaitForSeconds(1);
            yield return base.Exit();

        }

        public override void Update () {
            base.Update();
        }

    }

}