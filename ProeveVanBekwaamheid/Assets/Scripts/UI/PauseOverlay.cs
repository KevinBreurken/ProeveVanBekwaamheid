using UnityEngine;
using System.Collections;
using DG.Tweening;
using BaseFrame.QUI;
using BaseFrame.QStates;
using Base.Manager;
using System.Collections.Generic;

namespace Base.UI {

    /// <summary>
    /// Appears when the game is paused.
    /// </summary>
    public class PauseOverlay : MonoBehaviour {

        /// <summary>
        /// Reference to the resume button.
        /// </summary>
        public QUIButton resumeButton;

        /// <summary>
        /// Reference to the quit button.
        /// </summary>
        public QUIButton quitButton;

        /// <summary>
        /// Reference to the GameManager.
        /// </summary>
        public GameManager gameManager;

        private CanvasGroup canvasGroup;

        // Use this for initialization
        void Awake () {

            canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0;

            resumeButton.onClicked += ReturnToGame;
            quitButton.onClicked   += ReturnToMenu;

            resumeButton.usesTimeScale = false;
            quitButton.usesTimeScale = false;

        }

		/// <summary>
		/// Returns back to the menu state.
		/// </summary>
        private void ReturnToMenu () {

            CloseOverlay();
            gameManager.StopGame();

        }

		/// <summary>
		/// Returns back to the game state.
		/// </summary>
        private void ReturnToGame () {

            CloseOverlay();

        }

		/// <summary>
		/// Opens the overlay.
		/// </summary>
        public void OpenOverlay () {

            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.DOFade(1, 1).SetUpdate(true);
            Time.timeScale = 0;

        }

		/// <summary>
		/// Closes the overlay.
		/// </summary>
        public void CloseOverlay () {

            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.DOFade(0, 1).SetUpdate(true);
            Time.timeScale = 1;

        }

    }

}