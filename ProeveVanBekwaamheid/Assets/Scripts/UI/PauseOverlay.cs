using UnityEngine;
using System.Collections;
using DG.Tweening;
using BaseFrame.QUI;
using BaseFrame.QStates;
using Base.Manager;
using System.Collections.Generic;

namespace Base.UI {

    public class PauseOverlay : MonoBehaviour {

        private CanvasGroup canvasGroup;
        public QUIButton resumeButton;
        public QUIButton quitButton;
        public GameManager gameManager;

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