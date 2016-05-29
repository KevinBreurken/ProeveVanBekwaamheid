using UnityEngine;
using System.Collections;
using Base.Game;
using Base.UI;

namespace Base.Manager {

    /// <summary>
    /// Handles counting and time related game events.
    /// </summary>
    public class TimeManager : ManagerObject {

        public delegate void TimeEvent ();

        /// <summary>
        /// Is called when the timer has reached the level duration.
        /// </summary>
        public event TimeEvent onTimerEnded;

        /// <summary>
        /// How long the level takes. (in seconds)
        /// </summary>
        public int levelDuration;

        /// <summary>
        /// how long the level currently is playing. (in seconds)
        /// </summary>
        public float currentLevelDuration;

        /// <summary>
        /// Reference to the Timer Display.
        /// </summary>
        public TimerDisplay timerDisplay;

        public bool isTicking = true;

        /// <summary>
        /// Check to see if the game is started.
        /// </summary>
        private bool gameStarted;

        /// <summary>
        /// Starts the countdown timer.
        /// </summary>
        public void StartTimer () {

        }

        void Update () {

            if (gameStarted && isTicking) {
                currentLevelDuration += Time.deltaTime;
                
                if(GetCurrentLevelDuration() < 0) {
                    //Send the message that the game time has ended.
                    if (onTimerEnded != null) {

                        onTimerEnded();
                        currentLevelDuration = 0;

                    }
                }
            }

        }

      
        public override void Load () {

            base.Load();
            gameStarted = true;
            isTicking = true;
            currentLevelDuration = 0;

        }

        public override void Unload () {

            gameStarted = false;
            isTicking = false;
            base.Unload();

        }

        /// <summary>
        /// Receives when this level will end.
        /// </summary>
        /// <returns>Time until the level ends. (in seconds)</returns>
        public float GetCurrentLevelDuration () {

            float time = levelDuration - currentLevelDuration;
            return time;

        }

    }

}
