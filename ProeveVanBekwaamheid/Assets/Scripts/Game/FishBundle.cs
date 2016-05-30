﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Chanisco;

namespace Base.Game.Fish
{
    /// <summary>
    /// A collection of fish used by the FishBundleController.
    /// </summary>
    public class FishBundle : MonoBehaviour {
        /// <summary>
        /// A list that holds the fish that you can spawn in this wave
        /// </summary>
        public List<FishBehaviour> availableFish = new List<FishBehaviour>();

        /// <summary>
        /// The Controller that holds the Area's variables
        /// </summary>
        private AreaController areaController;

        /// <summary>
        /// The Area where the fish swim
        /// </summary>
        private Area seaArea;

        /// <summary>
        /// designates the required variables that needs to be called on start
        /// </summary>
        /// <param name="_parent"></param>
        public void Init()
        {
            areaController = AreaController.Instance;
            seaArea = areaController.seaField;
        }

        /// <summary>
        /// Starts the Routine that spawns fish also shuffles the list so the active fish will be random
        /// </summary>
        public void WaveStart()
        {
            availableFish.HeavyShuffle();
            StartCoroutine("SpawnFishWithDelay");
        }

        public void LevelEnd()
        {
            StopCoroutine("SpawnFishWithDelay");
        }
        /// <summary>
        /// Spawns the next inactive fish with a minor delay
        /// </summary>
        /// <returns></returns>
        IEnumerator SpawnFishWithDelay()
        {
            ChooseFish();
             yield return new WaitForSeconds(1);
            StartCoroutine("SpawnFishWithDelay");
        }

        /// <summary>
        /// Chooses the first target in the list that isn't active
        /// </summary>
        void ChooseFish()
        {
            for (int i = 0; i < availableFish.Count;i++)
            {
                if(availableFish[i].gameObject.activeSelf == false)
                {
                    ActivateFish(availableFish[i]);
                    break;
                }
            }
        }

        /// <summary>
        /// Activate target fish so it spawns in game
        /// </summary>
        /// <param name="_targetFish">Target fish you want to Spawn in the field</param>
        void ActivateFish(FishBehaviour _targetFish)
        {
            int randomNumber = Random.Range(0,2);
            float randomY = Random.Range(seaArea.yTop,seaArea.yBottom);
            switch (randomNumber)
            {
                case 0:
                    _targetFish.ownDirection = Direction.RIGHT;
                    _targetFish.fishArea = seaArea;
                    _targetFish.ActivateFish(new Vector2(seaArea.xLeft, randomY));
                break;
                case 1:
                    _targetFish.ownDirection = Direction.LEFT;
                    _targetFish.fishArea = seaArea;
                    _targetFish.ActivateFish(new Vector2(seaArea.xRight, randomY));
                break;
            }
        }
    }


}