﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BaseFrame.QStates {

    /// <summary>
    /// Switches Game State.
    /// </summary>
    public class GameStateSelector : QStateSelector {

		private static GameStateSelector instance = null;

        /// <summary>
        /// Static reference of the State Selector.
        /// </summary>
        public static GameStateSelector Instance {

            get {

                if (instance == null) {

                    instance = FindObjectOfType(typeof(GameStateSelector)) as GameStateSelector;

                }

                if (instance == null) {

                    //GameObject go = new GameObject("GameStateSelector");
                    //instance = go.AddComponent(typeof(GameStateSelector)) as GameStateSelector;

                }

                return instance;

            }

        }

        /// <summary>
        /// The first UIState that will be set active.
        /// </summary>
        public BaseGameState startGameState;

        public override void Awake () {

            base.Awake();

            if(startGameState != null)
            StartCoroutine(SetState(startGameState));

        }
    }

}
