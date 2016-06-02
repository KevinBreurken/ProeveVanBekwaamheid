using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using BaseFrame.QUI;

namespace Base.UI {

    /// <summary>
    /// Shows the player score and it's target score.
    /// </summary>
    public class ScoreDisplay : MonoBehaviour {

        /// <summary>
        /// Displays the current score.
        /// </summary>
        public Text currentScoreText;

        /// <summary>
        /// Displays the target score.
        /// </summary>
        public Text targetScoreText;

        /// <summary>
        /// Displays the added score.
        /// </summary>
        public QUIObject addedScoreQUIObject;
        private Text addedScoreQUIObjectText;
         
        private int tweenedScoreCounterValue;
        private int tweenedTargetScore;
        private int targetScoreSetValue;

        private CanvasGroup canvasGroup;

        void Awake () {

            addedScoreQUIObjectText = addedScoreQUIObject.GetComponent<Text>();
            addedScoreQUIObject.GetCanvasGroup().alpha = 0;
            canvasGroup = GetComponent<CanvasGroup>();

        }

        /// <summary>
        /// Updates the score counter.
        /// </summary>
        /// <param name="_score">The score the player currently has.</param>
        /// <param name="_addedScore">The score that is added to the player score.</param>
        public void UpdateScoreCounter (int _score,int _addedScore) {

            DOTween.Kill(103);
            DOTween.To(() => tweenedScoreCounterValue, x => tweenedScoreCounterValue = x, _score, 1.5f).SetId(103).OnUpdate(UpdateScoreText);

            if (addedScoreQUIObjectText == null)
                return;

            if (!addedScoreQUIObjectText.IsActive())
                return;

            addedScoreQUIObjectText.text = "+" + _addedScore; 
            StartCoroutine(addedScoreQUIObject.Show());

            addedScoreQUIObject.GetCanvasGroup().alpha = 0;
            addedScoreQUIObject.GetCanvasGroup().DOFade(1, 0.5f).OnComplete(OnAddedScoreQUIObjectFadeComplete);

        }

        /// <summary>
        /// Called when the added-score display is faded in.
        /// </summary>
        private void OnAddedScoreQUIObjectFadeComplete () {
            if (addedScoreQUIObjectText == null)
                return;

            if (!addedScoreQUIObjectText.IsActive())
                return;

            StartCoroutine(addedScoreQUIObject.Hide());
        }

        /// <summary>
        /// Updates the target score display.
        /// </summary>
        /// <param name="_targetScore"></param>
        public void UpdateTargetScoreDisplay(int _targetScore) {

            targetScoreSetValue = _targetScore;
            targetScoreText.rectTransform.DOLocalMoveX(targetScoreText.rectTransform.localPosition.x - 400, 2).OnComplete(ShowTargetScoreDisplay);

        }

        private void ShowTargetScoreDisplay () {

            DOTween.Kill(104);
            DOTween.To(() => tweenedTargetScore, x => tweenedTargetScore = x, targetScoreSetValue, 0.5f).SetId(104).OnUpdate(UpdateScoreTargetText);
            targetScoreText.text = "" + targetScoreSetValue;
            targetScoreText.rectTransform.DOLocalMoveX(targetScoreText.rectTransform.localPosition.x + 400, 1f);

        }

        /// <summary>
        /// Updates the score text. (called by the tween animation)
        /// </summary>
        private void UpdateScoreText () {

            currentScoreText.text = "" + tweenedScoreCounterValue;

        }

        /// <summary>
        /// Updates the score target text. (called by the tween animation)
        /// </summary>
        private void UpdateScoreTargetText () {

            targetScoreText.text = "" + tweenedTargetScore;

        }

        /// <summary>
        /// Resets the score counter.
        /// </summary>
        public void ResetCounter () {

            currentScoreText.text = "" + 0;
            targetScoreText.text = "" + 0;
            tweenedScoreCounterValue = 0;
            tweenedTargetScore = 0;
            targetScoreText.GetComponent<CanvasGroup>().alpha = 0;
            targetScoreText.GetComponent<CanvasGroup>().DOFade(1, 2);
        }

       
        /// <summary>
        /// Shows the score counter.
        /// </summary>
        /// <param name="_instant">If it's shown immediately. </param>
        public void Show (bool _instant) {

            if (_instant) {
                canvasGroup.alpha = 1;
                return;
            }

            canvasGroup.DOFade(1, 1);

        }

        /// <summary>
        /// Hides the score counter.
        /// </summary>
        /// <param name="_instant">If it's hidden immediately. </param>
        public void Hide(bool _instant) {

            if (_instant) {
                canvasGroup.alpha = 0;
                return;
            }

            canvasGroup.DOFade(0, 1);

        }

    }

}
