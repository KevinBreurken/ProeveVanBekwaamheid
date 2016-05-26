using UnityEngine;
using System.Collections;

namespace Base.Game.Fish {
	
	public class BlueFish : FishBehaviour {
		
	    public void Start() {
			
	        speed = Random.Range(1, 10);
	        ownStart();

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
