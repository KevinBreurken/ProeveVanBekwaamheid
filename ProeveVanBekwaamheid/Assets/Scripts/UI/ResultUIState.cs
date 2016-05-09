using UnityEngine;
using System.Collections;
using BaseFrame.QStates;
using BaseFrame.QUI;

namespace Base.UI {

    public class ResultUIState : BaseUIState {

        public BaseGameState offGameState;
        public QUIButton returnButton;
        public QUIButton playButton;

        void Awake () {

            returnButton.onClicked += ReturnButton_onClicked;

        }

        private void ReturnButton_onClicked () {

            StartCoroutine(UIStateSelector.Instance.SetState("MenuUIState"));

        }

        public override void Enter () {

            base.Enter();

            if (GameStateSelector.Instance.currentState != offGameState) {

                StartCoroutine(GameStateSelector.Instance.SetState(offGameState));

            }

        }

        public override IEnumerator Exit () {

            return base.Exit();

        }

    }

} 
