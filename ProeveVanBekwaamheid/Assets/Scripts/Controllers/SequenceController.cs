using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SequenceController : Singleton<SequenceController> {
    public List<FishSequence> StartGameSequence = new List<FishSequence>();


    public void CreateNewRandomSequence()
    {
        int AmountOfColors = Enum.GetValues(typeof(HookColors)).Length;
        FishSequence targetSequence = new FishSequence(new List<HookColors>(),false);
        for (int i = 0; i < AmountOfColors;i++)
        {
            HookColors targetColor = (HookColors)Enum.ToObject(typeof(HookColors), i);
            int AmountofFishes = UnityEngine.Random.Range(2,5);
            for(int j = 0; j < AmountofFishes; j++)
            {
                targetSequence.availableFishColors.Add(targetColor);
            }

            if(i == AmountOfColors - 1)
            {
                StartGameSequence.Add(targetSequence);
            }
        }
    }

    public void CreatePredeterminedSequence(int AmountOfFish)
    {

    }

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
