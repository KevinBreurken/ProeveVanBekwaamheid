using UnityEngine;
using System.Collections;
using BaseFrame.QStates;
using BaseFrame.QUI;
using Base.Manager;
using UnityEngine.UI;

namespace Base.UI {

    public class ResultUIState : BaseUIState {

        public WaveManager waveManager;
        public BaseGameState offGameState;

        [Header("Buttons")]
        public QUIButton returnButton;
        public QUIButton playButton;

        [Header("Other UI Components")]
        public QUIObject scoreObject;
        private Text scoreObjectText;
        public QUIObject levelObject;
        private Text levelObjectText;

        void Awake () {

            returnButton.onClicked += ReturnButton_onClicked;

            levelObjectText = levelObject.GetComponent<Text>();
            scoreObjectText = scoreObject.GetComponent<Text>();

        }

        private void ReturnButton_onClicked () {

            StartCoroutine(UIStateSelector.Instance.SetState("MenuUIState"));

        }

        public override void Enter () {

            base.Enter();

            //Get score and reached level.
            int score = Manager.ScoreManager.Instance.GetScore();
            int level = waveManager.currentLevel;

            scoreObjectText.text = "Score: " + score;
            levelObjectText.text = "Level: " + (level + 1);

            if (GameStateSelector.Instance.currentState != offGameState) {

                StartCoroutine(GameStateSelector.Instance.SetState(offGameState));

            }

            StartCoroutine(scoreObject.Show());
            StartCoroutine(levelObject.Show());

        }

        public override IEnumerator Exit () {

            return base.Exit();

        }

    }

} 
