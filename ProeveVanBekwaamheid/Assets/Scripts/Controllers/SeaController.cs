using UnityEngine;
using System.Collections;

namespace Base.Game.Fish {
	
	public class SeaController : Singleton<SeaController> {
	
	    public SeaPositioning seaPositioning;

	    void Start() {
			
	        if (seaPositioning == null)
	   		Debug.LogError("The Sea gameobject is empty, Check: " + "<color=red>" + gameObject.name + "</color>" + " if something is empty");
	        
	    }


	    /// <summary>
	    /// Movement for the sea
	    /// </summary>
	    /// <param name="Xpos">Direction where the sea should move to</param>
	    public void MoveSea(float _xPos) {
			
	        seaPositioning.MovePosition(_xPos);

	    }
		
	}

}