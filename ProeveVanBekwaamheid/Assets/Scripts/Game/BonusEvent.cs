using UnityEngine;
using System.Collections;
using Base.Manager;
using Base.UI;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Base.Game {

    /// <summary>
    /// A bonus event that allows the player to pick a chest for points.
    /// </summary>
    public class BonusEvent : MonoBehaviour {

        public delegate void BonusEventEvent();

        public event BonusEventEvent OnBonusEventFinished;
        public BonusChest[] chests;
        public List<int> pointAmount = new List<int>();

        public GameManager gameManager;
        public PlayerWheelBehaviour playerController;
        public TimeManager timeManager;
        public WaveManager waveManager;
        public CameraController cameraController;
        public NextLevelUINotification nextLevelNotification;
        public Text textPopup;
        private Vector3 textPopupStartingPosition;

        public int amountUntilEventHapens = 1;
        private bool isInProgress;

        void Awake () {

            //Add listeners
            waveManager.OnLevelEntered += WaveManager_OnLevelEntered;
            gameManager.onGameExited += GameManager_onGameExited;

            for (int i = 0; i < chests.Length; i++) {

                chests[i].OnChestOpened += BonusEvent_OnChestOpened;
                chests[i].OnChestOpenAnimationEnded += BonusEvent_OnChestAnimationEnded;
                chests[i].textPopup = textPopup;
            }

            textPopupStartingPosition = textPopup.transform.localPosition;

        }

        /// <summary>
        /// Called when the pressed chests animation ends.
        /// </summary>
        /// <param name="_chest">The chest that finished it's animation.</param>
        private void BonusEvent_OnChestAnimationEnded (BonusChest _chest) {

            _chest.Deactivate(0);
            DeactivateBonusEvent();
        }

        private void BonusEvent_OnChestOpened (BonusChest _chest) {

            for (int i = 0; i < chests.Length; i++) {

                if (chests[i] != _chest)
                    chests[i].Deactivate(0);

            }

            textPopup.transform.localPosition = textPopupStartingPosition;
            cameraController.target = _chest.transform;
            cameraController.movementSpeed = 0.3f;

        }

        private void GameManager_onGameExited () {
            //Disable chests.
            for (int i = 0; i < chests.Length; i++) {

                chests[i].Deactivate(3);
             
            }

            cameraController.target = playerController.transform;
            cameraController.movementSpeed = 2;

        }

        private void WaveManager_OnLevelEntered (int _enteredLevel) {
        
            if (_enteredLevel % amountUntilEventHapens == 0) {
                ActivateBonusEvent();
            }

        }

        private void ActivateBonusEvent () {

            isInProgress = true;

            //Stop player movement.
            playerController.recievesPlayerInput = false;
            //Pause the timer.
            timeManager.isTicking = false;
            //Focus Camera to event.
            cameraController.target = transform;
            //Enable chests.
            Chanisco.ChaniscoLib.Shuffle(pointAmount);
            for (int i = 0; i < chests.Length; i++) {
                chests[i].Activate();
                chests[i].SetScore(pointAmount[i]);
            }

        }

        public void DeactivateBonusEvent () {

            isInProgress = false; 
            //Stop player movement.
            playerController.recievesPlayerInput = true;
            //Un-pause the timer.
            timeManager.isTicking = true;
            //Focus Camera to event.
            cameraController.target = playerController.transform;
            cameraController.movementSpeed = 2;
            //Disable chests.
            for (int i = 0; i < chests.Length; i++) {
                chests[i].Deactivate(0);
            }
            //nextLevelNotification.
            if(OnBonusEventFinished != null)
            OnBonusEventFinished();

        }

    }

}