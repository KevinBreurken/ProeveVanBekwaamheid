using UnityEngine;
using System.Collections;
using BaseFrame.QEffect;
using BaseFrame.QInput;
using BaseFrame.QUI;
using BaseFrame.QStates;
using Base.Game;
using DG.Tweening;
using UnityEngine.Analytics;
using System.Collections.Generic;

namespace Base.UI {

    public class MenuUIState : BaseUIState {

        public BaseGameState offGameState;
        public BaseUIState gameUIState;

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
        private CanvasGroup stateCanvasGroup;

        //Used for analytics
        private int amountofTimePlayClicked;
        private bool hasOpenedInstructionsMenu;

        void Awake () {

            //Get references
            stateCanvasGroup = GetComponent<CanvasGroup>();
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
            startButton.onClicked += OnPlayClicked;
            QInputManager.Instance.onInputChanged += Instance_onInputChanged;

        }

        private void OnPlayClicked () {

            amountofTimePlayClicked++;
            Audio.AudioManager.Instance.SetUnderwaterMixing(1);
            Analytics.CustomEvent("Game_BackToMenuQuit", new Dictionary<string, object>
            {

              { "amountofTimePlayClicked", amountofTimePlayClicked },
              { "hasOpenedInstructionsMenu", hasOpenedInstructionsMenu },
              { "timeSinseApplicationStarted", Time.realtimeSinceStartup },

            });

            StartCoroutine(UIStateSelector.Instance.SetState(gameUIState));

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

                hasOpenedInstructionsMenu = true;
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

            if (GameStateSelector.Instance.currentState != offGameState) {

                StartCoroutine(GameStateSelector.Instance.SetState(offGameState));

            }

            optionsLayer.GetComponent<CanvasGroup>().alpha = 0;
            creditsLayer.GetComponent<CanvasGroup>().alpha = 0;
            instructionsLayer.GetComponent<CanvasGroup>().alpha = 0;


            stateCanvasGroup.alpha = 0;
            stateCanvasGroup.interactable = true;
            stateCanvasGroup.blocksRaycasts = true;

            StartCoroutine(WaitDelay());

        }

        private IEnumerator WaitDelay () {

            yield return new WaitForSeconds(1.5f);

           
            stateCanvasGroup.DOFade(1, 1.5f);

        }

        public override IEnumerator Exit () {

            stateCanvasGroup.alpha = 1;
            stateCanvasGroup.interactable = false;
            stateCanvasGroup.blocksRaycasts = false;
            stateCanvasGroup.DOFade(0, 1.5f);

            StartCoroutine(GameStateSelector.Instance.SetState("InGameState"));

            yield return new WaitForSeconds(3);
            base.Exit();

        }

        private void Instance_onInputChanged (BaseQInputMethod _changedMethod) {

            inputMethod = _changedMethod;

        }

        /// <summary>
        /// Called when the quit button is clicked.
        /// </summary>
        private void OnQuitClicked () {

            SetButtonState(false);
            EffectManager.Instance.FadeEffect.onFadeFinished += QuitGame;
            StartCoroutine(EffectManager.Instance.FadeEffect.Fade(0, -1, 1));

        }

        /// <summary>
        /// Closes the game.
        /// </summary>
        private void QuitGame () {

            Application.Quit();

        }
    }

}