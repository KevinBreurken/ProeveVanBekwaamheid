using UnityEngine;
using System.Collections;
using Base.Game.Hooks;
namespace Base.Game.Fish {

    /// <summary>
    /// Behaviour of the green fish.
    /// </summary>
    public class GreenFish : FishBehaviour {

	    public void Start() {
			
			currentSpeed = speed + Random.Range(-speedRandom, speedRandom);
	        Init();

	    }

	    public void OnEnable() {
			
			currentSpeed = speed + Random.Range(-speedRandom, speedRandom);
	        InMotion = true;

	    }

	    void FixedUpdate () {
			
	        SwimDirection(ownDirection);
	        OutOfBound();

	    }
        
	    public override void SetType() {
			
	        base.SetType();
            requiredHookColor = ColorEnum.GREEN;

	    }

	}

}
