using UnityEngine;
using System.Collections;
using Base.UI;
using Base.Game;

namespace Base.Manager {

    /// <summary>
    /// Manages the players score.
    /// </summary>
    public class ScoreManager : ManagerObject {

        private static ScoreManager instance = null;

        /// <summary>
        /// Static reference of the State Selector.
        /// </summary>
        public static ScoreManager Instance {

            get {

                if (instance == null) {

                    instance = FindObjectOfType(typeof(ScoreManager)) as ScoreManager;

                }

                return instance;

            }

        }

        /// <summary>
        /// The score the player currently has.
        /// </summary>
        private int currentScore;
        
        /// <summary>
        /// Reference to the Score Display.
        /// </summary>
        public ScoreDisplay scoreDisplay;

        /// <summary>
        /// Adds score to the player score.
        /// </summary>
        /// <param name="_value">The value thats added to the score.</param>
        public void AddScore (int _value) {

            currentScore += _value;
            scoreDisplay.UpdateScoreCounter(currentScore, _value);

        }

        /// <summary>
        /// Resets the score back to zero.
        /// </summary>
        public void ResetScore () {

            currentScore = 0;

        }

        /// <summary>
        /// Gets the score that the player made during this game.
        /// </summary>
        /// <returns>Player score.</returns>
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