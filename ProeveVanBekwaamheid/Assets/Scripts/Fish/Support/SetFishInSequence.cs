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
		
	    public bool routine;
	    public FishSpawnSequence target;

		void Update () {
			
		    if(routine == true) {
				
	            routine = false;
	            ResetArrays();
	            SetFunctionality();  

	        }

	        DestroyInPlayMode();

	    }

	    private void SetFunctionality() {
			
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