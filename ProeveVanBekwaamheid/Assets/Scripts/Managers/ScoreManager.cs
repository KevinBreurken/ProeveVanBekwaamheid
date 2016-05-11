using UnityEngine;
using System.Collections;
using Base.UI;
using Base.Game;

namespace Base.Manager {

    public class ScoreManager : InGameObject {

        private static ScoreManager instance = null;

        /// <summary>
        /// Static reference of the State Selector.
        /// </summary>
        public static ScoreManager Instance {

            get {

                if (instance == null) {

                    instance = FindObjectOfType(typeof(ScoreManager)) as ScoreManager;

                }

                if (instance == null) {

                    //GameObject go = new GameObject("GameStateSelector");
                    //instance = go.AddComponent(typeof(GameStateSelector)) as GameStateSelector;

                }

                return instance;

            }

        }

        public int currentScore;
        public ScoreDisplay scoreDisplay;

        public void AddScore (int _value) {

            currentScore += _value;
            scoreDisplay.UpdateScoreCounter(currentScore, _value);

        }

        public void ResetScore () {

            currentScore = 0;

        }

        void Update () {
            //Temp code for testing.
           /* if (Input.GetKeyDown(KeyCode.S)) {
                AddScore(100);
            }*/
        }

        public int GetScore () {

            return currentScore;

        }

        public override void Load () {

            base.Load();
            //Game is loaded. reset the score.
            ResetScore();
            scoreDisplay.ResetCounter();

        }

    }

}