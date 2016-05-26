﻿using UnityEngine;
using System.Collections;

namespace Base.Game.Fish {
	
	public class RedIntuition : FishInstinct {

	    public override void ReactOnFish(FishBehaviour _target) {
			
	        parent.emotion.Emote(Emotions.QUESTION);

	        if(_target.requiredHookColor == HookColors.RED) {
				
	            if (_target.ownDirection != parent.ownDirection) {
					
	                StartCoroutine("SwimOpositeDirection");

	            }

	        }

	    }

	}

}