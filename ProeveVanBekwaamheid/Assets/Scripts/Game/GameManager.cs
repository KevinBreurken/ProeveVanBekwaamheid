using UnityEngine;
using System.Collections;
using BaseFrame.QStates;
using Base.Manager;

namespace Base.Game {

    public class GameManager : MonoBehaviour {

		public PlayerBehaviour playerBoat;
        private ScoreManager scoreManager;
        private WaveManager waveManager;
        private TimeManager timeManager;

        void Awake () {

            //Get script references
            scoreManager = GetComponent<ScoreManager>();
            timeManager = GetComponent<TimeManager>();
            waveManager = GetComponent<WaveManager>();
            waveManager.OnWaveFailed += StopGame;
            waveManager.OnWaveSucceeded += WaveManager_OnWaveSucceeded;

        }

        private void WaveManager_OnWaveSucceeded () {
			
            scoreManager.scoreDisplay.UpdateScoreTarget(waveManager.targetScoreList[waveManager.currentLevel]);

        }

        public void StartGame () {

            Debug.Log("Game Manager started.");

			playerBoat.Load();

            scoreManager.Load();
            waveManager.Load();
            timeManager.Load();
            waveManager.BeginWaves();
            scoreManager.scoreDisplay.UpdateScoreTarget(waveManager.targetScoreList[waveManager.currentLevel]);

        }

        public void StopGame () {

            Debug.Log("Game Manager stopped.");

			playerBoat.Unload();

            scoreManager.Unload();
            waveManager.Unload();
            timeManager.Unload();
            StartCoroutine(UIStateSelector.Instance.SetState("MenuUIState"));

        }

    }

}
