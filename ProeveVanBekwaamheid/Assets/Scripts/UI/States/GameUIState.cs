using UnityEngine;
using System.Collections;
using BaseFrame.QStates;
using BaseFrame.QUI;
using BaseFrame.QEffect;
using DG.Tweening;

namespace Base.UI {

    /// <summary>
    /// UI State that is used in=game.
    /// </summary>
    public class GameUIState : BaseUIState {

        /// <summary>
        /// Reference of the pause button.
        /// </summary>
		public QUIButton pauseButton;
        
        /// <summary>
        /// Reference to the score display.
        /// </summary>
        public ScoreDisplay scoreDisplay;

        /// <summary>
        /// Reference to the timer display.
        /// </summary>
        public TimerDisplay timerDisplay;

        /// <summary>
        /// Reference to the pause overlay.
        /// </summary>
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
            timerDisplay.Hide(true);

        }

        /// <summary>
        /// Called when the pause button is clicked.
        /// </summary>
        void PauseButton_onClicked ()
        {
            pauseOverlay.OpenOverlay();
        }

        public override IEnumerator Exit () {

            canvasGroup.DOFade(0, 0.3f);
            yield return new WaitForSeconds(1);
            yield return base.Exit();

        }

    }

}