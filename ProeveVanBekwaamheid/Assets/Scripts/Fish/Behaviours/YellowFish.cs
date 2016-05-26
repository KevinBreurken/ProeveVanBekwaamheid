using UnityEngine;
using System.Collections;

namespace Base.Game.Fish {
	
	public class YellowFish : FishBehaviour {

	    public void Start() {
			
	        speed = Random.Range(20, 30);
	        ownStart();

	    }

	    public void OnEnable() {
			
	        speed = Random.Range(20, 30);
	        InMotion = true;

	    }

	    void Update() {
			
	        SwimDirection(ownDirection);
	        OutOfBound();

	    }

		/// <summary>
		/// See BaseClass function.
		/// </summary>
	    public override void SetType() {
			
	        base.SetType();
	        requiredHookColor = HookColors.YELLOW;

	    }

	}

}