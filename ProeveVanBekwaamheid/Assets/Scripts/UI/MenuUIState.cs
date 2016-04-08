using UnityEngine;
using System.Collections;
using QStates;
using QEffect;
using QInput;
using Base.Game;

namespace Base.UI {

    public class MenuUIState : BaseUIState {

        private BaseQInputMethod inputMethod;
        public BaseGameState gameState;

        void Awake () {

            QInputManager.Instance.onInputChanged += Instance_onInputChanged;
            inputMethod = QInputManager.Instance.GetCurrentInputMethod();

        }

        private void Instance_onInputChanged (BaseQInputMethod _changedMethod) {

            inputMethod = _changedMethod;

        }

        public override void Enter () {

            base.Enter();
            if(GameStateSelector.Instance.currentState != gameState) {

                StartCoroutine(GameStateSelector.Instance.SetState(gameState));

            }

            StartCoroutine(EffectManager.Instance.fadeEffect.TryToFade(0, -1, 1));

        }

        public override IEnumerator Exit () {

            return base.Exit();

        }

        public override void Update () {

            base.Update();

        }

    }

}