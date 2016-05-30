using UnityEngine;
using System.Collections;
using BaseFrame.QStates;
using Base.Manager;
using Base.Game;

namespace Base.Manager {

	/// <summary>
	/// Manages Game related actions.
	/// </summary>
    public class GameManager : MonoBehaviour {

        public delegate void GameEvent (int _currentLevel, int _targetscore);
        public delegate void GameEnterEvent ();

        /// <summary>
        /// Called when a new level is entered.
        /// </summary>
        public event GameEvent onNextLevelEntered;

        /// <summary>
        /// Called when the game is entered.
        /// </summary>
        public event GameEnterEvent onGameEntered;
        /// <summary>
        /// Called when the game is left.
        /// </summary>
        public event GameEnterEvent onGameExited;

        /// <summary>
        /// Reference to the Player Behaviour.
        /// </summary>
        public PlayerWheelBehaviour playerBoat;

        /// <summary>
        /// Reference to the Bonus Event.
        /// </summary>
        public BonusEvent bonusEvent;

        private ScoreManager scoreManager;
        private WaveManager waveManager;
        private TimeManager timeManager;

        void Awake () {

            //Get script references
            scoreManager = GetComponent<ScoreManager>();
            timeManager = GetComponent<TimeManager>();
            waveManager = GetComponent<WaveManager>();

			//add listeners
            waveManager.OnWaveFailed += StopGame;
            waveManager.OnWaveSucceeded += StartNewLevel;
            bonusEvent.OnBonusEventFinished += BonusEvent_OnBonusEventFinished;
        }

        private void BonusEvent_OnBonusEventFinished () {

            int currentLevel = waveManager.currentLevelIndex;
            int targetScore = waveManager.targetScoreList[currentLevel];

            scoreManager.scoreDisplay.UpdateTargetScoreDisplay(targetScore);

            if(onNextLevelEntered != null)
            onNextLevelEntered(currentLevel, targetScore);

        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void StartGame () {

            Debug.Log("Game Manager started.");

			playerBoat.Load();
            scoreManager.Load();
            waveManager.Load();
            timeManager.Load();

            waveManager.StartWaveSequence();
            scoreManager.scoreDisplay.UpdateTargetScoreDisplay(waveManager.targetScoreList[waveManager.currentLevelIndex]);
            scoreManager.scoreDisplay.Show(false);
            timeManager.timerDisplay.Show(false);

            if (onGameEntered != null)
                onGameEntered();

        }

        /// <summary>
        /// Stops the game.
        /// </summary>
        public void StopGame () {

            Debug.Log("Game Manager stopped.");

			playerBoat.Unload();
            scoreManager.Unload();
            waveManager.Unload();
            timeManager.Unload();

            if (onGameExited != null)
                onGameExited();

            StartCoroutine(UIStateSelector.Instance.SetState("ResultUIState"));

        }

        /// <summary>
        /// Starts a new level.
        /// </summary>
        public void StartNewLevel () {

            int currentLevel = waveManager.currentLevelIndex;
            int targetScore = waveManager.targetScoreList[currentLevel];

            scoreManager.scoreDisplay.UpdateTargetScoreDisplay(targetScore);

            if ((currentLevel + 1) % bonusEvent.amountUntilEventHapens != 0)
                if (onNextLevelEntered != null)
                    onNextLevelEntered(currentLevel, targetScore);

        }

    }

}
