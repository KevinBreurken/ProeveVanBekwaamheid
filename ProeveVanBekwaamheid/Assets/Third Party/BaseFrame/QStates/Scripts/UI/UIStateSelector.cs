using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace QStates {


    public class UIStateSelector : QStateSelector {

        protected static UIStateSelector instance = null;

        /// <summary>
        /// Static reference of the State Selector.
        /// </summary>
        public static UIStateSelector Instance {

            get {

                if (instance == null) {

                    instance = FindObjectOfType(typeof(UIStateSelector)) as UIStateSelector;

                }

                if (instance == null) {

                    GameObject go = new GameObject("UIStateSelector");
                    instance = go.AddComponent(typeof(UIStateSelector)) as UIStateSelector;

                }

                return instance;

            }

        }

        /// <summary>
        /// The first UIState that will be set active.
        /// </summary>
        public BaseUIState startUIState;

        public void Start () {

            StartCoroutine(SetState(startUIState));

        }

    }

}
