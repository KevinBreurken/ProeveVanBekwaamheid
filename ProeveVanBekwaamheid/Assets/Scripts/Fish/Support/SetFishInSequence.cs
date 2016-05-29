using UnityEngine;
using System.Collections;
using Base.Game.Hooks;

namespace Base.Game.Fish {

	/// <summary>
	/// This scripts is only made for faster implementation
	/// This script puts all the childeren fish in the gameobject 
	/// </summary>
	[ExecuteInEditMode]
	public class SetFishInSequence : MonoBehaviour {

	    public FishSpawnSequence target;

		void Update () {
            if(target == null) {
                target = GetComponentInParent<FishSpawnSequence>();
            }
	        DestroyInPlayMode();

	    }

	    public void SetFunctionality() {

            ResetArrays();
            FishBehaviour[] tempFish = GetComponentsInChildren<FishBehaviour>();
	        for (int i = 0;i < transform.childCount;i++) {
				
	            if (tempFish[i].requiredHookColor == ColorEnum.GREEN) {
                    target.greenFishes.Add(tempFish[i]);
	            } else if (tempFish[i].requiredHookColor == ColorEnum.RED) {

                    target.redFishes.Add(tempFish[i]);

	            } else if (tempFish[i].requiredHookColor == ColorEnum.YELLOW) {
                    target.yellowFishes.Add(tempFish[i]);

	            }

	        }
            Debug.Log("<color=blue>[SEQUENCE COMPLETE]</color>");
	    }

	    private void DestroyInPlayMode() {
			
	        if (Application.isPlaying) {
				
	            DestroyImmediate(this);

	        }

	    }

	    private void ResetArrays() {
			
	        target.greenFishes.Clear();
	        target.redFishes.Clear();
	        target.yellowFishes.Clear();

	    }

	}

}