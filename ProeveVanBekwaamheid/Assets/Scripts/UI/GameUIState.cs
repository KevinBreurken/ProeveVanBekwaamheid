using UnityEngine;
using System.Collections;
using BaseFrame.QStates;
using BaseFrame.QUI;
using BaseFrame.QEffect;
using DG.Tweening;

namespace Base.UI {

    public class GameUIState : BaseUIState {

		public QUIButton pauseButton;

		void Awake () {

			pauseButton.onClicked += PauseButton_onClicked;

		}

        public override void Enter () {

            base.Enter();

        }

        void PauseButton_onClicked ()
        {
			
        }

        public override IEnumerator Exit () {

            return base.Exit();
        }

        public override void Update () {
            base.Update();
        }

    }

}