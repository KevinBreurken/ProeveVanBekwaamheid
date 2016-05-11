using UnityEngine;
using System.Collections;
using BaseFrame.QUI;
using UnityEngine.UI;
using Base.Manager;
using DG.Tweening;

namespace Base.UI {

    public class TimerDisplay : MonoBehaviour {

        public TimeManager timeManager;

        public QUIObject timeQUIObject;
        private Text timeQUIObjectText;

        private CanvasGroup canvasGroup;
        private int previousRoundedTimeValue;
        private int time;
        private bool isActive;

        void Awake () {

            canvasGroup = GetComponent<CanvasGroup>();
            timeQUIObjectText = timeQUIObject.GetComponent<Text>();

        }

        // Update is called once per frame
        void Update () {

            if (!isActive)
                return;

            time = (int)System.Math.Round(timeManager.GetCurrentLevelDuration(),0);
            timeQUIObjectText.text = "" + time;

            if(time != previousRoundedTimeValue) {
                previousRoundedTimeValue = time;
                StartCoroutine(timeQUIObject.Show());
            }

        }

        public void Show (bool _instant) {

            if (_instant) {
                canvasGroup.alpha = 1;
                return;
            }

            canvasGroup.DOFade(1, 1);
            isActive = true;

        }

        public void Hide (bool _instant) {

            if (_instant) {
                canvasGroup.alpha = 0;
                return;
            }

            canvasGroup.DOFade(0, 1);
            isActive = false;

        }


    }

}
