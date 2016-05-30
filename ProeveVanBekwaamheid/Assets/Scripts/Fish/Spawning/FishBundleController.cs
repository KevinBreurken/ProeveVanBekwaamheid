using UnityEngine;
using System.Collections;

namespace Base.Game.Fish {

    /// <summary>
    /// Spawns and controls FishBundles.
    /// </summary>
    public class FishBundleController: Singleton<FishBundleController> {

        /// <summary>
        /// Functions to create new fishes into the game
        /// </summary>
        public FishCreation fishCreation;
        /// <summary>
        /// Bundle holding the available fish
        /// </summary>
        public FishBundle fishBundle;
        /// <summary>
        /// Sequence for the spawning of the fishes in the current wave
        /// </summary>
        public FishSpawnSequence fishSpawnSequence;

        void Start() {

            Init();

        }
        

        /// <summary>
        /// Init that sets the variables on start
        /// </summary>
        void Init() {

            fishCreation = GetComponent<FishCreation>();
            fishBundle = GetComponent<FishBundle>();
            fishSpawnSequence = GetComponent<FishSpawnSequence>();

            fishBundle.Init();
            fishSpawnSequence.Init(this);
            OnWaveStart(0);

        }

        /// <summary>
        /// The function that calls the fishes in the according level
        /// </summary>
        /// <param name="_targetLevel">the target wave that is now active</param>
        public void OnWaveStart(int _targetLevel) {  

            if(fishSpawnSequence.WaveStart(_targetLevel) == true) 
                fishBundle.WaveStart();

        }

    }
}
