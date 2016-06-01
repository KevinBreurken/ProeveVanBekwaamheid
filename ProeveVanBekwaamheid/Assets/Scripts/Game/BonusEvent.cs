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

        /// <summary>
        /// Called when the bonus event is finished.
        /// </summary>
        public event BonusEventEvent onBonusEventFinished;
        /// <summary>
        /// The Chests used in the event.
        /// </summary>
        public BonusChest[] chests;
        /// <summary>
        /// Which amount of points the chests contain.
        /// </summary>
        public List<int> pointAmount = new List<int>();

        /// <summary>
        /// Reference to the GameManager.
        /// </summary>
        public GameManager gameManager;
        /// <summary>
        /// Reference to the PlayerBehaviour
        /// </summary>
        public PlayerWheelBehaviour playerController;
        /// <summary>
        /// Reference to the TimeManager.
        /// </summary>
        public TimeManager timeManager;
        /// <summary>
        /// Reference to the WaveManager.
        /// </summary>
        public WaveManager waveManager;
        /// <summary>
        /// Reference to the CameraController.
        /// </summary>
        public CameraController cameraController;
        /// <summary>
        /// Reference to the NextLevelUINotification.
        /// </summary>
        public NextLevelUINotification nextLevelNotification;
        /// <summary>
        /// The Text component that displays the score amount.
        /// </summary>
        public Text textPopup;
        /// <summary>
        /// the starting position of the textPopup.
        /// </summary>
        private Vector3 textPopupStartingPosition;

        /// <summary>
        /// after what amount the bonus event happens (every x amount)
        /// </summary>
        public int amountUntilEventHapens = 1;
        /// <summary>
        /// If the event is in progress.
        /// </summary>
        private bool isInProgress;

        void Awake () {

            //Add listeners
            waveManager.onLevelEntered += WaveManager_OnLevelEntered;
            gameManager.onGameExited += GameManager_onGameExited;

            for (int i = 0; i < chests.Length; i++) {

                chests[i].onChestOpened += BonusEvent_OnChestOpened;
                chests[i].onChestOpenAnimationEnded += BonusEvent_OnChestAnimationEnded;
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

        /// <summary>
        /// Called when the chest is opened.
        /// </summary>
        private void BonusEvent_OnChestOpened (BonusChest _chest) {

            for (int i = 0; i < chests.Length; i++) {

                if (chests[i] != _chest)
                    chests[i].Deactivate(0);

            }

            textPopup.transform.localPosition = textPopupStartingPosition;
            cameraController.target = _chest.transform;
            cameraController.movementSpeed = 0.3f;

        }

        /// <summary>
        /// Called When the game is exited.
        /// </summary>
        private void GameManager_onGameExited () {
            //Disable chests.
            for (int i = 0; i < chests.Length; i++) {

                chests[i].Deactivate(3);

            }

            cameraController.target = playerController.transform;
            cameraController.movementSpeed = 2;

        }

        /// <summary>
        /// Called when a level is entered.
        /// </summary>
        private void WaveManager_OnLevelEntered (int _enteredLevel) {

            if (_enteredLevel % amountUntilEventHapens == 0) {
                ActivateBonusEvent();
            }

        }

        /// <summary>
        /// Activates the bonus event.
        /// </summary>
        private void ActivateBonusEvent () {

            isInProgress = true;

            //Stop player movement.
            playerController.recievesPlayerInput = false;
			playerController.Recenter();
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

        /// <summary>
        /// Deactivates the bonus event.
        /// </summary>
        public void DeactivateBonusEvent () {

            isInProgress = false;
            //Stop player movement.
            playerController.recievesPlayerInput = true;
			playerController.StopRecenter();
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
            if (onBonusEventFinished != null)
                onBonusEventFinished();


        }

    }

}