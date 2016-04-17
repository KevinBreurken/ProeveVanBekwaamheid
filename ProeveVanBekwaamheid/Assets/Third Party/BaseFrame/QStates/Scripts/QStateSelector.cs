using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BaseFrame.QStates {

	/// <summary>
	/// Switches between QStates. Acts as BaseClass for UIStates and GameStates.
	/// </summary>
    public class QStateSelector : MonoBehaviour {

        /// <summary>
        /// All UIStates that are being used.
        /// </summary>
        public List<GameObject> States = new List<GameObject>();

        /// <summary>
        /// The current UIState that is active.
        /// </summary>
        public QState currentState;

        /// <summary>
        /// The UIState that will be entered after the current active state is left.
        /// </summary>
        public QState nextState;

        /// <summary>
        /// The previous UIState that was used.
        /// </summary>
        public QState previousState;

        /// <summary>
        /// The first State that will be set active.
        /// </summary>
        public QState startState;

		/// <summary>
		/// Called first by Unity3D.
		/// </summary>
        public virtual void Awake () {
            //Disable all UIStates.
            for (int i = 0; i < States.Count; i++) {

                States[i].SetActive(false);

            }

            if (startState != null)
                StartCoroutine(SetState(startState));

        }
        
        /// <summary>
        /// Gets the state by its name.
        /// </summary>
        /// <param name="_stateName">The name of the state.</param>
        /// <returns>The found state.</returns>
        public QState GetState(string _stateName) {

            QState foundState = null;
            //Get the next state.
            for (int i = 0; i < States.Count; i++) {

                if (States[i].GetComponent<QState>().GetType().ToString().Contains(_stateName)) {

                    foundState = States[i].GetComponent<QState>();

                }

            }

            return foundState;

        }

        /// <summary>
        /// Changes the State by its name.
        /// </summary>
        /// <param name="_nextState">the name of the state.</param>
        public void SetState (string _nextState) {

            QState foundState = null;
            //Get the next state.
            for (int i = 0; i < States.Count; i++) {

                if (States[i].GetComponent<QState>().GetType().ToString().Contains(_nextState)) {

                    foundState = States[i].GetComponent<QState>();

                }

            }

            if (foundState == null) {

                Debug.LogError("[ERROR]: state [" + _nextState + "] not found.");

            }

            StartCoroutine(SetState(foundState));
            
        }
        
		/// <summary>
		/// Adds a state to the state list.
		/// </summary>
		/// <param name="_state">The state.</param>
        public void AddState(GameObject _state) {

            States.Add(_state);

        }

        /// <summary>
        /// Changes the State.
        /// </summary>
        /// <param name="_nextState">The new state.</param>
        public IEnumerator SetState (QState _nextState) {

            if(_nextState == currentState) {

                Debug.Log("State " + _nextState.name + " is already open.");

            }

            nextState = _nextState;

            if (currentState != null) {

                yield return StartCoroutine(currentState.Exit());
                currentState.Disable();
                previousState = currentState;

            }

            currentState = nextState;
            currentState.Enter();
            nextState = null;
            OnStateEntered();

        }

        /// <summary>
        /// Called when the state is entered.
        /// </summary>
        public virtual void OnStateEntered () {

        }

    }

}