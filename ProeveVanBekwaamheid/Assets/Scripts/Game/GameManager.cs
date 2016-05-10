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
        public event GameEvent onNextLevelEntered;

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

        public void StartGame () {

            Debug.Log("Game Manager started.");

			playerBoat.Load();
            scoreManager.Load();
            waveManager.Load();
            timeManager.Load();

            waveManager.BeginWaves();
            scoreManager.scoreDisplay.UpdateScoreTarget(waveManager.targetScoreList[waveManager.currentLevel]);
            scoreManager.scoreDisplay.Show(false);

        }

        public void StopGame () {

            Debug.Log("Game Manager stopped.");

			playerBoat.Unload();
            scoreManager.Unload();
            waveManager.Unload();
            timeManager.Unload();

            StartCoroutine(UIStateSelector.Instance.SetState("ResultUIState"));

        }

        public void StartNewLevel () {

            int currentLevel = waveManager.currentLevel;
            int targetScore = waveManager.targetScoreList[currentLevel];

            scoreManager.scoreDisplay.UpdateScoreTarget(targetScore);

            onNextLevelEntered(currentLevel, targetScore);

        }

    }

}
