using UnityEngine;
using System.Collections;
using BaseFrame.QStates;
using Base.Manager;

namespace Base.Manager {

	/// <summary>
	/// Manages Game related actions.
	/// </summary>
    public class GameManager : MonoBehaviour {

        public delegate void GameEvent (int _currentLevel, int _targetscore);

        /// <summary>
        /// Called when a new level is entered.
        /// </summary>
        public event GameEvent onNextLevelEntered;

        /// <summary>
        /// reference to the boat (player behaviour)
        /// </summary>
        public PlayerBehaviour playerBoat;

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

            StartCoroutine(UIStateSelector.Instance.SetState("ResultUIState"));

        }

        /// <summary>
        /// Starts a new level.
        /// </summary>
        public void StartNewLevel () {

            int currentLevel = waveManager.currentLevelIndex;
            int targetScore = waveManager.targetScoreList[currentLevel];

            scoreManager.scoreDisplay.UpdateTargetScoreDisplay(targetScore);

            onNextLevelEntered(currentLevel, targetScore);

        }

    }

}
