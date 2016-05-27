using UnityEngine;
using System.Collections;
using Base.Game.Hooks;

namespace Base.Game.Fish {
	/// <summary>
    /// Behaviour of the Bluefish
    /// </summary>
	public class BlueFish : FishBehaviour {
		
	    public void Start() {
			
	        speed = Random.Range(1, 10);
	        Init();

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
            requiredHookColor = ColorEnum.YELLOW;   

	    }

	}

}
