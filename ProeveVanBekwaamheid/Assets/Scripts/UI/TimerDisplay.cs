﻿using UnityEngine;
using System.Collections;
using BaseFrame.QUI;
using UnityEngine.UI;
using Base.Manager;
using DG.Tweening;

namespace Base.UI {

    /// <summary>
    /// Displays the time left in the level.
    /// </summary>
    public class TimerDisplay : MonoBehaviour {

        /// <summary>
        /// Reference to the time manager.
        /// </summary>
        public TimeManager timeManager;

        /// <summary>
        /// Displays the time.
        /// </summary>
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

        void Update () {

            if (!isActive)
                return;

            time = (int)System.Math.Round(timeManager.GetCurrentLevelDuration(),0);

            int minutes = Mathf.FloorToInt(time / 60F);
            int seconds = Mathf.FloorToInt(time - minutes * 60);
            string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            timeQUIObjectText.text = "" + niceTime;

            if(time != previousRoundedTimeValue) {
                previousRoundedTimeValue = time;
                StartCoroutine(timeQUIObject.Show());
            }

        }

        /// <summary>
        /// Shows the time display.
        /// </summary>
        /// <param name="_instant">If it's shown immediately. </param>
        public void Show (bool _instant) {

            if (_instant) {
                canvasGroup.alpha = 1;
                return;
            }

            canvasGroup.DOFade(1, 1);
            isActive = true;

        }

        /// <summary>
        /// Hides the time display.
        /// </summary>
        /// <param name="_instant">If it's hidden immediately. </param>
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
