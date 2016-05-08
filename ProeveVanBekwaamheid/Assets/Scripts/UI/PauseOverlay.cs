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

            resumeButton.onClicked += ResumeButton_onClicked;
            quitButton.onClicked += QuitButton_onClicked;
            resumeButton.usesTimeScale = false;
            quitButton.usesTimeScale = false;

        }

        private void QuitButton_onClicked () {

            CloseOverlay();
            gameManager.StopGame();

        }

        private void ResumeButton_onClicked () {

            CloseOverlay();

        }

        public void OpenOverlay () {

            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.DOFade(1, 1).SetUpdate(true);
            Time.timeScale = 0;

        }

        public void CloseOverlay () {

            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.DOFade(0, 1).SetUpdate(true);
            Time.timeScale = 1;

        }

    }

}