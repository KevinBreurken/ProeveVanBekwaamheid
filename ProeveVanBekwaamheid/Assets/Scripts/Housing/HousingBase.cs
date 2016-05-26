using UnityEngine;
using System.Collections;

namespace Base.Game.Fish {
	
	public class HousingBase : MonoBehaviour {
		
	    public bool occupied;

		void OnTriggerEnter2D(Collider2D _other) {
			
	        if (_other.gameObject.tag == "Fish")
	            InteractWithFish();
	        
	    }

	    public virtual void InteractWithFish() {

	    }

	    public void ClaimOwnership(FishInstinct _target) {
			
	        occupied = true;

	    }

	    public void LoseOwnership() {
			
	        occupied = false;

	    }

	}

}

