using UnityEngine;
using System.Collections;
using QStates;
using QEffect;
using QInput;
using QUI;
using Base.Game;

namespace Base.UI {

    public class MenuUIState : BaseUIState {

        public BaseGameState gameState;

        [Header("Button")]
        public QUIButton startButton;
        public QUIToggle instructionsButton;
        public QUIToggle optionsButton;
        public QUIToggle creditsButton;
        public QUIButton quitButton;
        private QUIToggle currentActiveToggle;

        [Header("Layers")]
        public QUIObject instructionsLayer;
        public QUIObject optionsLayer;
        public QUIObject creditsLayer;
        private QUIObject currentOpenLayer;

        private BaseQInputMethod inputMethod;

       

        void Awake () {

            QInputManager.Instance.onInputChanged += Instance_onInputChanged;
            inputMethod = QInputManager.Instance.GetCurrentInputMethod();

            //Removes the quit button if its a WebGL game (may need a android/IOS check as well.
            #if UNITY_WEBGL
            quitButton.gameObject.SetActive(false);
            #endif

            //Add event listeners
            optionsButton.onToggleClicked += OnToggleButtonClicked;
            creditsButton.onToggleClicked += OnToggleButtonClicked;
            instructionsButton.onToggleClicked += OnToggleButtonClicked;
            quitButton.onClicked += OnQuitClicked;

        }

        private void OnToggleButtonClicked (bool _state,QUIToggle _toggledObject) {

            SetButtonState(false);

            StopAllCoroutines();
            if (currentActiveToggle == _toggledObject) {

                if (_toggledObject == creditsButton     ) { StartCoroutine(CloseLayer(creditsLayer));      }
                if (_toggledObject == optionsButton     ) { StartCoroutine(CloseLayer(optionsLayer));      }
                if (_toggledObject == instructionsButton) { StartCoroutine(CloseLayer(instructionsLayer)); }

                currentActiveToggle = null;
                return;

            }
            
            creditsButton.SetToggleStateRough(false);
            optionsButton.SetToggleStateRough(false);
            instructionsButton.SetToggleStateRough(false);

            if(_toggledObject == creditsButton) {
                creditsButton.SetToggleStateRough(true);
                StartCoroutine(OpenLayer(creditsLayer));
            }

            if (_toggledObject == optionsButton) {
                optionsButton.SetToggleStateRough(true);
                StartCoroutine(OpenLayer(optionsLayer));
            }

            if (_toggledObject == instructionsButton) {
                instructionsButton.SetToggleStateRough(true);
                StartCoroutine(OpenLayer(instructionsLayer));
            }

            currentActiveToggle = _toggledObject;

        }

        private void SetButtonState (bool _state) {

            creditsButton.SetInteractable(_state);
            optionsButton.SetInteractable(_state);
            instructionsButton.SetInteractable(_state);
            quitButton.SetInteractable(_state);
            startButton.SetInteractable(_state);

        }

        private IEnumerator OpenLayer (QUIObject _layer) {

            if(currentOpenLayer != null) {

                yield return StartCoroutine(CloseLayer(currentOpenLayer));

            }

            currentOpenLayer = _layer;
            yield return StartCoroutine(_layer.Show());
            SetButtonState(true);

        }

        private IEnumerator CloseLayer (QUIObject _layer) {

            yield return StartCoroutine(_layer.Hide());
            currentOpenLayer = null;
            SetButtonState(true);

        }

        

        public override void Enter () {

            base.Enter();

            if(GameStateSelector.Instance.currentState != gameState) {

                StartCoroutine(GameStateSelector.Instance.SetState(gameState));

            }

            optionsLayer.GetComponent<CanvasGroup>().alpha = 0;
            creditsLayer.GetComponent<CanvasGroup>().alpha = 0;
            instructionsLayer.GetComponent<CanvasGroup>().alpha = 0;

            StartCoroutine(EffectManager.Instance.fadeEffect.TryToFade(0, -1, 1));

        }

        public override IEnumerator Exit () {

            return base.Exit();

        }

        public override void Update () {

            base.Update();

        }

        private void Instance_onInputChanged (BaseQInputMethod _changedMethod) {

            inputMethod = _changedMethod;

        }

        /// <summary>
        /// Called when the quit button is clicked.
        /// </summary>
        private void OnQuitClicked () {

            SetButtonState(false);
            EffectManager.Instance.fadeEffect.onFadeFinished += QuitGame;
            StartCoroutine(EffectManager.Instance.fadeEffect.Fade(1, -1, 0));

        }

        /// <summary>
        /// Closes the game.
        /// </summary>
        private void QuitGame () {

            Application.Quit();

        }
    }

}