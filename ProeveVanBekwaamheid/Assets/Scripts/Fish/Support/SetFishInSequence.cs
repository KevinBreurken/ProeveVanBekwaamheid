using UnityEngine;
using System.Collections;

/// <summary>
/// This scripts is only made for faster implementation
/// This script puts all the childeren fish in the gameobject 
/// </summary>
[ExecuteInEditMode]
public class SetFishInSequence : MonoBehaviour {
    public bool routine;
    public FishSpawnSequence target;
	void Update () {
	    if(routine == true)
        {
            routine = false;
            SetFunctionality();   
        }
	}

    void SetFunctionality()
    {
        FishBehaviour[] tempFish = GetComponentsInChildren<FishBehaviour>();
        for (int i = 0;i < transform.childCount;i++)
        {
            if (tempFish[i].requiredHookColor == HookColors.GREEN)
            {
                target.greenFishes.Add(tempFish[i]);
            }
            else if (tempFish[i].requiredHookColor == HookColors.RED)
            {
                target.redFishes.Add(tempFish[i]);
            }
            else if (tempFish[i].requiredHookColor == HookColors.YELLOW)
            {
                target.yellowFishes.Add(tempFish[i]);
            }
        }
    }
}
