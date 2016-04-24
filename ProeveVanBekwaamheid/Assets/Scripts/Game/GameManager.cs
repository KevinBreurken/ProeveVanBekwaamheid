using UnityEngine;
using System.Collections;

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

        }

        public void StartGame () {

            Debug.Log("Game Manager started.");

			playerBoat.Load();

            scoreManager.Load();
            waveManager.Load();
            timeManager.Load();
            waveManager.BeginWaves();

        }

        public void StopGame () {

            Debug.Log("Game Manager stopped.");

			playerBoat.Unload();

            scoreManager.Unload();
            waveManager.Unload();
            timeManager.Unload();

        }

    }

}
