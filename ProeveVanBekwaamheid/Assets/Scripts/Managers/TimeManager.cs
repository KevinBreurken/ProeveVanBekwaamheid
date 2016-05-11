using UnityEngine;
using System.Collections;
using Base.Game;
using Base.UI;

namespace Base.Manager {

    public class TimeManager : InGameObject {

        public delegate void TimeEvent ();

        public event TimeEvent onTimerEnded;

        public int levelLenght;

        public float totalGameDuration;
        public bool gameStarted;
        public TimerDisplay timerDisplay;


        public void StartTimer () {

            StartCoroutine(WaitTillLevelEnds());

        }

        void Update () {

            totalGameDuration += Time.deltaTime;

        }

        private IEnumerator WaitTillLevelEnds () {

            Debug.Log("Timer started");

            yield return new WaitForSeconds(levelLenght);

            Debug.Log("Timer ended");

            //Send the message that the game time has ended.
            if (onTimerEnded != null) {

                onTimerEnded();

            }

        }

        public override void Load () {

            base.Load();
            gameStarted = true;
            totalGameDuration = 0;

        }

        public override void Unload () {

            gameStarted = false;
            StopCoroutine(WaitTillLevelEnds());
            base.Unload();

        }

        public float GetCurrentLevelDuration () {

            float time = 0;
            time = levelLenght - totalGameDuration;
            return time;

        }

    }

}
