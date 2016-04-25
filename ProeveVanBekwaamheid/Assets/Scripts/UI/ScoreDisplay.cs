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
        public int currentScoreCounterValue;
        public int currentMatchScore;
        
        void Awake () {

            addedScoreQUIObjectText = addedScoreQUIObject.GetComponent<Text>();
            addedScoreQUIObject.GetCanvasGroup().alpha = 0;

        }

        public void UpdateScoreCounter (int _score,int _addedScore) {

            currentMatchScore = _score;
            DOTween.Kill(103);
            DOTween.To(() => currentScoreCounterValue, x => currentScoreCounterValue = x, currentMatchScore, 1.5f).SetId(103).OnUpdate(UpdateScoreText);

            addedScoreQUIObjectText.text = "+" + _addedScore; 
            StartCoroutine(addedScoreQUIObject.Show());
            addedScoreQUIObject.GetCanvasGroup().alpha = 0;
            addedScoreQUIObject.GetCanvasGroup().DOFade(1, 0.5f).OnComplete(OnAddedScoreQUIObjectFadeComplete);

        }

        private void OnAddedScoreQUIObjectFadeComplete () {
            StartCoroutine(addedScoreQUIObject.Hide());
        }

        private void UpdateScoreText () {

            currentScoreText.text = "" + currentScoreCounterValue;

        }

        public void UpdateScoreTarget(int _targetScore) {

            targetScoreText.text = "" + _targetScore;

        }

        public void ResetCounter () {

            currentScoreText.text = "" + 0;
            targetScoreText.text = "" + 0;
            currentScoreCounterValue = 0;

        }

    }

}
