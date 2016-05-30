﻿using UnityEngine;
using System.Collections;
using Base.Game.Hooks;

namespace Base.Game.Fish {

    /// <summary>
    /// Defines how the green fish behaves.
    /// </summary>
    public class RedIntuition : FishInstinct {

	    public override void ReactOnFish(FishBehaviour _target) {
			
	        parent.emotion.Emote(Emotions.QUESTION);

	        if(_target.requiredHookColor == ColorEnum.RED) {
				
	            if (_target.ownDirection != parent.ownDirection) {

                    StartCoroutine("SwimOpositeDirection");

	            }

	        }

	    }

	}

}