﻿using UnityEngine;
using System.Collections;
using Base.Game.Hooks;

namespace Base.Game.Fish {

    public class FishCreation: MonoBehaviour {

        /// <summary>
        /// The Gameobject of the red fish
        /// </summary>
        public GameObject redFishObject;

        /// <summary>
        /// The Gameobject of the green fish
        /// </summary>
        public GameObject greenFishObject;

        /// <summary>
        /// The Gameobject of the yellow fish
        /// </summary>
        public GameObject yellowFishObject;

        /// <summary>
        /// The sequence that has the information for all the predetermined waves
        /// </summary>
        public FishSpawnSequence _fishSpawnSequenceHolder;

        /// <summary>
        /// The bundle that keeps track of the fishes in the wave
        /// </summary>
        public FishBundle _fishBundle;

        /// <summary>
        /// Creates a fish and inserts it in the required fields
        /// </summary>
        /// <param name="targetColor">The color that the fish needs to be</param>
        /// <param name="addToBundle">Should the fish be added to the bundle or should it just be made</param>
        public void CreateFish(ColorEnum targetColor,bool addToBundle) {
            switch (targetColor) {
                case ColorEnum.RED:
                InstansiateFish(redFishObject,addToBundle);
                break;
                case ColorEnum.GREEN:
                InstansiateFish(greenFishObject,addToBundle);
                break;
                case ColorEnum.YELLOW:
                InstansiateFish(yellowFishObject,addToBundle);
                break;
            }
        }

        /// <summary>
        /// The Instansiating function that creates the fishes
        /// </summary>
        /// <param name="targetObject">The object that needs to be created</param>
        /// <param name="addToBundle">Does it has to be added to the bundle</param>
        public void InstansiateFish(GameObject targetObject,bool addToBundle) {
            GameObject target = Instantiate(targetObject,Vector3.zero,Quaternion.identity) as GameObject;
            FishBehaviour tempTargetBehaviour = target.GetComponent<FishBehaviour>();
            target.transform.parent = transform;
            target.name = targetObject.name;
            _fishSpawnSequenceHolder.yellowFishes.Add(target.GetComponent<FishBehaviour>());
            if (addToBundle == true) {
                _fishBundle.availableFish.Add(tempTargetBehaviour);

            }
        }
    }
}