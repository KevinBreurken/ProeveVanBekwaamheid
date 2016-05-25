using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SequenceController : Singleton<SequenceController> {
    public List<FishSequence> StartGameSequence = new List<FishSequence>();


}


[System.Serializable]
public class FishSequence
{
    public List<HookColors> availableFishColors;
    public bool bonusFish;
    public FishSequence(List<HookColors> AvailableFishColors,bool BonusFish)
    {
        this.availableFishColors = AvailableFishColors;
        this.bonusFish = BonusFish;

    }
}
