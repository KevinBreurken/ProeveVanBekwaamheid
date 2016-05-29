using UnityEngine;
using System.Collections;

namespace Base.Game.Fish {

    public class FishBundleController: Singleton<FishBundleController> {

        /// <summary>
        /// Functions to create new fishes into the game
        /// </summary>
        public FishCreation _fishCreation;
        /// <summary>
        /// Bundle holding the available fish
        /// </summary>
        public FishBundle _fishBundle;
        /// <summary>
        /// Sequence for the spawning of the fishes in the current wave
        /// </summary>
        public FishSpawnSequence _fishSpawnSequence;

        void Start() {

            Init();

        }
        

        /// <summary>
        /// Init that sets the variables on start
        /// </summary>
        void Init() {

            _fishCreation = GetComponent<FishCreation>();
            _fishBundle = GetComponent<FishBundle>();
            _fishSpawnSequence = GetComponent<FishSpawnSequence>();

            _fishBundle.Init();
            _fishSpawnSequence.Init(this);
            OnWaveStart(0);

        }

        public void OnWaveStart(int _targetLevel) {  

            if(_fishSpawnSequence.WaveStart(_targetLevel) == true) 
                _fishBundle.WaveStart();

        }

    }
}
