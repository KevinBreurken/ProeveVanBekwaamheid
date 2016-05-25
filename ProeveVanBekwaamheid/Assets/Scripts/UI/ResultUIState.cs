using UnityEngine;
using System.Collections;
using BaseFrame.QStates;
using BaseFrame.QUI;
using Base.Manager;
using UnityEngine.UI;
using DG.Tweening;

namespace Base.UI {

	/// <summary>
	/// UIState that shows the results of the game to the player.
	/// </summary>
    public class ResultUIState : BaseUIState {

		/// <summary>
		/// The QUIButton that returns the player back to the menu.
		/// </summary>
        [Header("Buttons")]
        public QUIButton returnButton;

		/// <summary>
		/// The QUIButton that returns the player back to the game.
		/// </summary>
        public QUIButton playButton;

		/// <summary>
		/// QUIObject that contains the score text component.
		/// </summary>
        [Header("Other UI Components")]
        public QUIObject scoreObject;
        private Text scoreObjectText;

		/// <summary>
		/// QUIObject that contains the level text component.
		/// </summary>
        public QUIObject levelObject;
        private Text levelObjectText;

		/// <summary>
		/// Reference to the WaveManager.
		/// </summary>
		[Header("Other")]
		public WaveManager waveManager;

		/// <summary>
		/// The GameState that is paired with this UIState.
		/// </summary>
		public BaseGameState gameState;

		private CanvasGroup canvasGroup;

        public QUIObject highscoreDisplay;
        public Text highscoreText;
        private Text highscoreDisplayText;

        void Awake () {

			//Add button listeners.
            returnButton.onClicked += ReturnToMenu;
			playButton.onClicked += ReturnToGameState;

			//Get component references.
            levelObjectText = levelObject.GetComponent<Text>();
            scoreObjectText = scoreObject.GetComponent<Text>();

			canvasGroup = GetComponent<CanvasGroup>();
            highscoreDisplayText = highscoreDisplay.GetComponent<Text>();

        }

		/// <summary>
		/// Returns back to the menu.
		/// </summary>
        private void ReturnToMenu () {

            StartCoroutine(UIStateSelector.Instance.SetState("MenuUIState"));

        }

		/// <summary>
		/// Returns back to the game.
		/// </summary>
        void ReturnToGameState () {
			
			Audio.AudioManager.Instance.SetUnderwaterMixing(1);
			StartCoroutine(UIStateSelector.Instance.SetState("GameUIState"));
			StartCoroutine(GameStateSelector.Instance.SetState("InGameState"));

        }

        public override void Enter () {

            base.Enter();

            //Get score and reached level.
            int score = Manager.ScoreManager.Instance.GetScore();
            int level = waveManager.currentLevelIndex;

			//Apply values to text components.
            scoreObjectText.text = "Score: " + score;
            levelObjectText.text = "Level: " + (level + 1);

			//Change the GameState if it isn't that state.
            if (GameStateSelector.Instance.currentState != gameState) {

                StartCoroutine(GameStateSelector.Instance.SetState(gameState));

            }

			//Perform animations.
			canvasGroup.alpha = 0;
			canvasGroup.DOFade(1,1);
            StartCoroutine(scoreObject.Show());
            StartCoroutine(levelObject.Show());

            int highscore = PlayerPrefs.GetInt("HighScore", 0);
            if(highscore < score) {

                PlayerPrefs.SetInt("HighScore", score);
                StartCoroutine(highscoreDisplay.Show());
                highscoreText.text = "New Highscore!";

            } else {

                highscoreText.text = "Highscore:";

            }

            highscoreDisplayText.text = "" + highscore;

        }

        public override IEnumerator Exit () {

			canvasGroup.alpha = 1;
			canvasGroup.DOFade(0,1);
			yield return new WaitForSeconds(1);
            base.Exit();

        }

    }

} 
