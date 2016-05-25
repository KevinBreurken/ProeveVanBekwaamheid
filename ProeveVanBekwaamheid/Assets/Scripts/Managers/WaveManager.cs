using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BaseFrame.QAudio;
using Base.Game;

namespace Base.Manager {

    /// <summary>
    /// Handles wave related actions when a level is won or lost.
    /// </summary>
    public class WaveManager : ManagerObject {

        public delegate void WaveEvent ();

        /// <summary>
        /// Called when the score requirement isn't met.
        /// </summary>
        public event WaveEvent OnWaveFailed;

        /// <summary>
        /// Called when the score requirement is met.
        /// </summary>
        public event WaveEvent OnWaveSucceeded;

        /// <summary>
        /// The score requirement for each wave.
        /// </summary>
        public List<int> targetScoreList = new List<int>();

        /// <summary>
        /// Audio that plays when a new level is entered.
        /// </summary>
        public QAudioObjectHolder nextLevelSoundNotification;

        /// <summary>
        /// the index of the level the game is currently on.
        /// for the current level increase it's value by one.
        /// </summary>
        public int currentLevelIndex;

        /// <summary>
        /// Reference to the TimeManager.
        /// </summary>
        private TimeManager timeManager;

        /// <summary>
        /// Reference to the ScoreManager.
        /// </summary>
        private ScoreManager scoreManager;

        void Awake () {

            //Get script references
            timeManager = GetComponent<TimeManager>();
            scoreManager = GetComponent<ScoreManager>();

            //Add listeners.
            timeManager.onTimerEnded += TimeManager_onTimerEnded;
            OnWaveSucceeded += WaveManager_OnWaveSucceeded;

            //Create audio.
            nextLevelSoundNotification.CreateAudioObject();

        }

        private void WaveManager_OnWaveSucceeded () {

            timeManager.StartTimer();
            nextLevelSoundNotification.GetAudioObject().Play();

        }

        private void TimeManager_onTimerEnded () {

            //Check if the player has reached its goal.
            int score = scoreManager.GetScore();

            if (score >= targetScoreList[currentLevelIndex]) {
                //Player has high enough score to reach the next level.
                Debug.Log("Player has high enough score, begin next wave.");

                currentLevelIndex++;

                if (OnWaveSucceeded != null) {

                    OnWaveSucceeded();

                }


            } else {

                //Player has insufficient score to reach the next level. lost game.
                Debug.Log("Player has low score, stop game.");

                if (OnWaveFailed != null) {

                    OnWaveFailed();

                }

            }

        }

        /// <summary>
        /// Starts the TimeManager. 
        /// the time manager calls back to this Class when the level is ended.
        /// </summary>
        public void StartWaveSequence () {

            timeManager.StartTimer();

        }

        public override void Load () {

            base.Load();
            currentLevelIndex = 0;

        }

    }

}