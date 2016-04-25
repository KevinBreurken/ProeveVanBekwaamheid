using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BaseFrame.QAudio;
using Base.Game;

namespace Base.Manager {

    public class WaveManager : InGameObject {

        public delegate void WaveEvent ();

        public event WaveEvent OnWaveFailed;

        public List<int> targetScoreList = new List<int>();
        public QAudioObjectHolder nextLevelSoundNotification;

        private TimeManager timeManager;
        private ScoreManager scoreManager;
        private int currentLevel;

        void Awake () {

            //Get script references
            timeManager = GetComponent<TimeManager>();
            scoreManager = GetComponent<ScoreManager>();
            timeManager.onTimerEnded += TimeManager_onTimerEnded;
            nextLevelSoundNotification.CreateAudioObject();

        }

        private void TimeManager_onTimerEnded () {

            //Check if the player has reached its goal.
            int score = scoreManager.GetScore();

            if (score >= targetScoreList[currentLevel]) {
                //Player has high enough score to reach the next level.
                Debug.Log("Player has high enough score, begin next wave.");
                timeManager.StartTimer();
                nextLevelSoundNotification.GetAudioObject().Play();

            } else {
                //Player has insufficient score to reach the next level. lost game.
                Debug.Log("Player has low score, stop game.");

                if (OnWaveFailed != null) {

                    OnWaveFailed();

                }

            }

        }

        public void BeginWaves () {

            timeManager.StartTimer();

        }

        public override void Load () {

            base.Load();
            currentLevel = 0;

        }

    }

}