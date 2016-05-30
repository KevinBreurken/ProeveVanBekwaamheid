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
using BaseFrame.QAudio;

namespace Base.UI {

    /// <summary>
    /// UI State that is used in the menu.
    /// </summary>
    public class MenuUIState : BaseUIState {

        /// <summary>
        /// Reference to the game state outside of the game.
        /// </summary>
        [Header("States")]
        public BaseGameState offGameState;

        /// <summary>
        /// Reference to the game UI state.
        /// </summary>
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

        [Header("Music")]
        public bool usesMelody = false;
        public QAudioObjectHolder menuMelody;
        public float menuMelodyWaitTime;


        private CanvasGroup canvasGroup;

        void Awake () {

            //Get references
            canvasGroup = GetComponent<CanvasGroup>();

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

            //create audio
            menuMelody.CreateAudioObject();
        }

        /// <summary>
        /// Called when the play button is clicked.
        /// </summary>
        private void OnPlayClicked () {

            Audio.AudioManager.Instance.SetUnderwaterMixing(1);
          
            StartCoroutine(UIStateSelector.Instance.SetState(gameUIState));

        }

        /// <summary>
        /// Called when a toggle button is clicked.
        /// </summary>
        /// <param name="_state">Which state the toggle is in.</param>
        /// <param name="_toggledObject">The toggle that is called.</param>
        private void OnToggleButtonClicked (bool _state,QUIToggle _toggledObject) {

            SetRowInteractableState(false);

            StopAllCoroutines();

            //If a already toggled layer is toggled.
            if (currentActiveToggle == _toggledObject) {

                if (_toggledObject == creditsButton     ) { StartCoroutine(CloseLayer(creditsLayer));      }
                if (_toggledObject == optionsButton     ) { StartCoroutine(CloseLayer(optionsLayer));      }
                if (_toggledObject == instructionsButton) { StartCoroutine(CloseLayer(instructionsLayer)); }

                currentActiveToggle = null;
                return;

            }
            
            //Sets the toggle back to its normal value.
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

        /// <summary>
        /// Plays the secret melody.
        /// </summary>
        /// <returns></returns>
        private IEnumerator PlaySecretMelody () {

            yield return new WaitForSeconds(menuMelodyWaitTime);

            QAudioObject secretMelodyObject = menuMelody.GetAudioObject();
            secretMelodyObject.FadeVolume(0.2f, 0.2f, 0.1f);
            secretMelodyObject.Play();

        }

        /// <summary>
        /// Sets the row of button to a set state.
        /// </summary>
        /// <param name="_state">The state it's set to.</param>
        private void SetRowInteractableState (bool _state) {

            creditsButton.SetInteractable(_state);
            optionsButton.SetInteractable(_state);
            instructionsButton.SetInteractable(_state);
            quitButton.SetInteractable(_state);
            startButton.SetInteractable(_state);

        }

        /// <summary>
        /// Opens a layer.
        /// </summary>
        /// <param name="_layer">The layer that's opened.</param>
        private IEnumerator OpenLayer (QUIObject _layer) {

            if(currentOpenLayer != null) {

                yield return StartCoroutine(CloseLayer(currentOpenLayer));

            }

            currentOpenLayer = _layer;

            yield return StartCoroutine(_layer.Show());

            SetRowInteractableState(true);

        }

        /// <summary>
        /// Closes a layer.
        /// </summary>
        /// <param name="_layer">The layer that's closed.</param>
        private IEnumerator CloseLayer (QUIObject _layer) {

            yield return StartCoroutine(_layer.Hide());

            currentOpenLayer = null;
            SetRowInteractableState(true);

        }

       
        public override void Enter () {

            base.Enter();

            if (GameStateSelector.Instance.currentState != offGameState) {

                StartCoroutine(GameStateSelector.Instance.SetState(offGameState));

            }

            optionsLayer.GetComponent<CanvasGroup>().alpha = 0;
            creditsLayer.GetComponent<CanvasGroup>().alpha = 0;
            instructionsLayer.GetComponent<CanvasGroup>().alpha = 0;


            canvasGroup.alpha = 0;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

            currentOpenLayer = null;
            currentActiveToggle = null;

            if(usesMelody)
            StartCoroutine(PlaySecretMelody());

            StartCoroutine(FadeCanvasGroup());

        }

        /// <summary>
        /// Fades the canvasGroup of this state.
        /// </summary>
        private IEnumerator FadeCanvasGroup () {

            yield return new WaitForSeconds(1.5f);

            canvasGroup.DOFade(1, 1.5f);

        }

        public override IEnumerator Exit () {

            canvasGroup.alpha = 1;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.DOFade(0, 1.5f);

            QAudioObject melodyObject = menuMelody.GetAudioObject();
            if (melodyObject.GetSource().isPlaying)
                melodyObject.FadeVolume(0.2f, 0, 2);


            StopCoroutine(PlaySecretMelody());

            StartCoroutine(GameStateSelector.Instance.SetState("InGameState"));

            yield return new WaitForSeconds(3);
            base.Exit();

        }

        /// <summary>
        /// Called when the quit button is clicked.
        /// </summary>
        private void OnQuitClicked () {

            SetRowInteractableState(false);
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