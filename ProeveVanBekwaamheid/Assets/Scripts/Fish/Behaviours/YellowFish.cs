using UnityEngine;
using System.Collections;
using Base.Game.Hooks;

namespace Base.Game.Fish {

    /// <summary>
    /// Behaviour of the yellow fish.
    /// </summary>
    public class YellowFish : FishBehaviour {

	    public void Start() {
			
			currentSpeed = speed + Random.Range(-speedRandom, speedRandom);
	        Init();

	    }

	    public void OnEnable() {
			
			currentSpeed = speed + Random.Range(-speedRandom, speedRandom);
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