using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using BaseFrame.QUI;
using DG.Tweening;
using Base.Manager;

namespace Base.UI {

    /// <summary>
    /// Appears when a level is completed.
    /// </summary>
    public class NextLevelUINotification : MonoBehaviour {

        /// <summary>
        /// Reference to the GameManager.
        /// </summary>
        [Header("Required references")]
        public GameManager gameManager;

        /// <summary>
        /// The QUIObject that show which level currently is played.
        /// </summary>
        [Header("Components")]
        public QUIObject levelQUIObject;

        /// <summary>
        /// The QUIObject that displays the target score.
        /// </summary>
        public QUIObject targetscoreQUIObject;

        /// <summary>
        /// How long the notification stays open.
        /// </summary>
        [Header("Time values")]
        public float openLength;
        
        /// <summary>
        /// How fast it fades in/out.
        /// </summary>
        public float fadeSpeed;

        /// <summary>
        /// Reference of the Text component in the levelQUIObject.
        /// </summary>
        private Text levelText;

        /// <summary>
        /// Reference of the Text component in the targetscoreQuiObject.
        /// </summary>
        private Text targetscoreText;

        private int enteredLevel;
        private int targetScore;

        private CanvasGroup canvasGroup;
        private const string LEVELTEXT = "Level ";
        private const string TARGETSCORETEXT = "Target score: ";

        void Awake () {

            //Get references
            levelText = levelQUIObject.GetComponent<Text>();
            targetscoreText = targetscoreQUIObject.GetComponent<Text>();
            canvasGroup = GetComponent<CanvasGroup>();

            //Add listener to game manager.
            gameManager.onNextLevelEntered += GameManager_onNextLevelEntered;

            //Hide the layer
            canvasGroup.alpha = 0;

        }

        private void GameManager_onNextLevelEntered (int _currentLevel, int _targetscore) {

            enteredLevel = _currentLevel;
            targetScore = _targetscore;
            ShowNotification();

        }

        /// <summary>
        /// Shows the next level notification.
        /// </summary>
        public void ShowNotification () {

            //Set the values of the text component
            levelText.text = LEVELTEXT + (enteredLevel + 1).ToString();
            targetscoreText.text = TARGETSCORETEXT + targetScore.ToString();

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

            //Start the close animation
            StartCoroutine(levelQUIObject.Hide());
            StartCoroutine(targetscoreQUIObject.Hide());
            canvasGroup.DOFade(0, fadeSpeed);

        }

    }

}