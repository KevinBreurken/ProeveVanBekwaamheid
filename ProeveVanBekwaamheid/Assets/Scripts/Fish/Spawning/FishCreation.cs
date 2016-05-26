using UnityEngine;
using System.Collections;
using Base.Game.Hooks;
namespace Base.Game.Fish {
		
	public class FishCreation : MonoBehaviour {

	    public GameObject redFishObject;
	    public GameObject greenFishObject;
	    public GameObject yellowFishObject;

	    public FishSpawnSequence fishSpawnSequenceHolder;
	    public FishBundle fishBundle;
	    

	    public void CreateFish(HookColors _targetColor, bool _addToBundle) {
			
	        switch (_targetColor) {

	            case HookColors.RED:
	                InstantiateFish(redFishObject, _addToBundle);
	                break;

	            case HookColors.GREEN:
	                InstantiateFish(greenFishObject, _addToBundle);
	                break;

	            case HookColors.YELLOW:
	                InstantiateFish(yellowFishObject, _addToBundle);
	                break;

	        }

	    }

	    public void InstantiateFish(GameObject _targetObject, bool _addToBundle) {
			
	        GameObject target = Instantiate(_targetObject, Vector3.zero, Quaternion.identity) as GameObject;
	        FishBehaviour tempTargetBehaviour = target.GetComponent<FishBehaviour>();
	        target.transform.parent = transform;
	        target.name = _targetObject.name;
	        fishSpawnSequenceHolder.yellowFishes.Add(target.GetComponent<FishBehaviour>());

	        if (_addToBundle == true)
	            fishBundle.availableFish.Add(tempTargetBehaviour);

	    }

	}   

}