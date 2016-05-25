using UnityEngine;
using System.Collections;

public class FishCreation : MonoBehaviour {

    public GameObject redFishObject;
    public GameObject greenFishObject;
    public GameObject yellowFishObject;

    public FishSpawnSequence _fishSpawnSequenceHolder;
    public FishBundle _fishBundle;
    

    public void CreateFish(HookColors targetColor, bool addToBundle)
    {
        switch (targetColor)
        {
            case HookColors.RED:
                InstansiateFish(redFishObject, addToBundle);
                break;
            case HookColors.GREEN:
                InstansiateFish(greenFishObject, addToBundle);
                break;
            case HookColors.YELLOW:
                InstansiateFish(yellowFishObject, addToBundle);
                break;
        }
    }

    public void InstansiateFish(GameObject targetObject, bool addToBundle)
    {
        GameObject target = Instantiate(targetObject, Vector3.zero, Quaternion.identity) as GameObject;
        FishBehaviour tempTargetBehaviour = target.GetComponent<FishBehaviour>();
        target.transform.parent = transform;
        target.name = targetObject.name;
        _fishSpawnSequenceHolder.yellowFishes.Add(target.GetComponent<FishBehaviour>());
        if (addToBundle == true)
        {
            _fishBundle.availableFish.Add(tempTargetBehaviour);

        }
    }
}   