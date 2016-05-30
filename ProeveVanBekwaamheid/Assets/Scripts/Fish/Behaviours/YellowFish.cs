﻿using UnityEngine;
using System.Collections;
using Base.Game.Hooks;

namespace Base.Game.Fish {
	
	public class YellowFish : FishBehaviour {

	    public void Start() {
			
	        speed = Random.Range(20, 30);
	        Init();

	    }

	    public void OnEnable() {
			
	        speed = Random.Range(20, 30);
	        InMotion = true;

	    }

	    void Update() {
			
	        SwimDirection(ownDirection);
	        OutOfBound();

	    }


	    public override void SetType() {
			
	        base.SetType();
            requiredHookColor = ColorEnum.YELLOW;

	    }

	}

}