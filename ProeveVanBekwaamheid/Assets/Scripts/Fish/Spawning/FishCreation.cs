using UnityEngine;
using System.Collections;
using Base.Game.Hooks;

namespace Base.Game.Fish {

    public class FishCreation: MonoBehaviour {

        public GameObject redFishObject;
        public GameObject greenFishObject;
        public GameObject yellowFishObject;

        public FishSpawnSequence _fishSpawnSequenceHolder;
        public FishBundle _fishBundle;


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