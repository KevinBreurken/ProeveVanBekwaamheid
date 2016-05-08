using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using BaseFrame.QUI;
using DG.Tweening;
using Base.Manager;

namespace Base.UI {

    public class NextLevelUINotification : MonoBehaviour {

        [Header("Required references")]
        public GameManager gameManager;

        [Header("Components")]

        [Tooltip("The QUIObject that shows which level is entered.")]
        public QUIObject levelQUIObject;

        [Tooltip("The QUIObject that shows the required target score for the entered level.")]
        public QUIObject targetscoreQUIObject;


        [Header("Time values")]
        
        [Tooltip("How long the notification will stay open.")]
        public float openLength;
        
        [Tooltip("How long it takes for this UI layer to fade to its alpha value.")]
        public float fadeSpeed;

        private Text levelText;
        private Text targetscoreText;
        private CanvasGroup canvasGroup;

        private const string LEVELTEXT = "Level ";
        private const string TARGETSCORETEXT = "Target score: ";

        void Awake () {

            //Get references
            levelText = levelQUIObject.GetComponent<Text>();
            targetscoreText = targetscoreQUIObject.GetComponent<Text>();
            canvasGroup = GetComponent<CanvasGroup>();

            //Add listener to game manager.
            gameManager.onNextLevelEntered += ShowNotification;

            //Hide the layer
            canvasGroup.alpha = 0;

        }

        public void ShowNotification (int _currentLevel, int _targetScore) {

            //Set the values of the text component
            levelText.text = LEVELTEXT + (_currentLevel + 1).ToString();
            targetscoreText.text = TARGETSCORETEXT + _targetScore.ToString();

            //Start the opening animation
            StartCoroutine(levelQUIObject.Show());
            StartCoroutine(targetscoreQUIObject.Show());
            canvasGroup.alpha = 0;
            canvasGroup.DOFade(1, fadeSpeed);

            //Start the timer
            StartCoroutine(WaitToCloseNotification());

        }

        private IEnumerator WaitToCloseNotification () {

            yield return new WaitForSeconds(openLength);

            HideNotification();

        }

        public void HideNotification () {

            //Start the opening animation
            StartCoroutine(levelQUIObject.Hide());
            StartCoroutine(targetscoreQUIObject.Hide());
            canvasGroup.DOFade(0, fadeSpeed);

        }

    }

}