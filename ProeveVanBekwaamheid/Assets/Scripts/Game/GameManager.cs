using UnityEngine;
using System.Collections;

namespace Base.Game {

    public class GameManager : MonoBehaviour {

		public PlayerBehaviour playerBoat;


        public void StartGame () {

            Debug.Log("Game Manager started.");
			playerBoat.Load();

        }

        public void StopGame () {

            Debug.Log("Game Manager stopped.");
			playerBoat.Unload();

        }

    }

}
