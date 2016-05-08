using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using BaseFrame.QUI;

namespace Base.UI {

    public class ScoreDisplay : MonoBehaviour {

        public Text currentScoreText;
        public Text targetScoreText;

        public QUIObject addedScoreQUIObject;
        private Text addedScoreQUIObjectText;
       
        public int currentMatchScore;
        public int currentTargetScore;

        private int tweenedScoreCounterValue;
        private int tweenedTargetScore;

        private CanvasGroup canvasGroup;

        void Awake () {

            addedScoreQUIObjectText = addedScoreQUIObject.GetComponent<Text>();
            addedScoreQUIObject.GetCanvasGroup().alpha = 0;
            canvasGroup = GetComponent<CanvasGroup>();

        }

        public void UpdateScoreCounter (int _score,int _addedScore) {

            currentMatchScore = _score;
            DOTween.Kill(103);
            DOTween.To(() => tweenedScoreCounterValue, x => tweenedScoreCounterValue = x, currentMatchScore, 1.5f).SetId(103).OnUpdate(UpdateScoreText);

            addedScoreQUIObjectText.text = "+" + _addedScore; 
            StartCoroutine(addedScoreQUIObject.Show());

            addedScoreQUIObject.GetCanvasGroup().alpha = 0;
            addedScoreQUIObject.GetCanvasGroup().DOFade(1, 0.5f).OnComplete(OnAddedScoreQUIObjectFadeComplete);

        }

        private void OnAddedScoreQUIObjectFadeComplete () {
            StartCoroutine(addedScoreQUIObject.Hide());
        }

        

        public void UpdateScoreTarget(int _targetScore) {

            currentTargetScore = _targetScore;
            targetScoreText.text = "" + _targetScore;
            DOTween.Kill(104);
            DOTween.To(() => tweenedTargetScore, x => tweenedTargetScore = x, currentTargetScore, 0.5f).SetId(104).OnUpdate(UpdateScoreTargetText);


        }

        private void UpdateScoreText () {

            currentScoreText.text = "" + tweenedScoreCounterValue;

        }

        private void UpdateScoreTargetText () {

            targetScoreText.text = "" + tweenedTargetScore;

        }

        public void ResetCounter () {

            currentScoreText.text = "" + 0;
            targetScoreText.text = "" + 0;
            tweenedScoreCounterValue = 0;
            tweenedTargetScore = 0;

        }

        public void Show (bool _instant) {

            if (_instant) {
                canvasGroup.alpha = 1;
                return;
            }

            canvasGroup.DOFade(1, 1);

        }

        public void Hide(bool _instant) {

            if (_instant) {
                canvasGroup.alpha = 0;
                return;
            }

            canvasGroup.DOFade(0, 1);

        }

    }

}
