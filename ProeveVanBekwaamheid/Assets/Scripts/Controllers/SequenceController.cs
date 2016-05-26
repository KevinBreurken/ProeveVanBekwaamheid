using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Base.Game.Hooks;

namespace Base.Game {
	
	public class SequenceController : Singleton<SequenceController> {
		
	    public List<FishSequence> StartGameSequence = new List<FishSequence>();

	    public void CreateNewRandomSequence() {
			
	        int AmountOfColors = Enum.GetValues(typeof(ColorEnum)).Length;
            FishSequence targetSequence = new FishSequence(new List<ColorEnum>(),false);

	        for (int i = 0; i < AmountOfColors;i++) {

                ColorEnum targetColor = (ColorEnum)Enum.ToObject(typeof(ColorEnum), i);
	            int AmountofFishes = UnityEngine.Random.Range(2,5);

	            for(int j = 0; j < AmountofFishes; j++)
	                targetSequence.availableFishColors.Add(targetColor);
	            

	            if(i == AmountOfColors - 1)
	                StartGameSequence.Add(targetSequence);
	            
	        }

	    }
	    
	}


	[System.Serializable]
	public class FishSequence {
		
	    public List<ColorEnum> availableFishColors;
	    public bool bonusFish;

	    public FishSequence(List<ColorEnum> _availableFishColors,bool _bonusFish) {
			
	        this.availableFishColors = _availableFishColors;
	        this.bonusFish = _bonusFish;

	    }

	}

}
