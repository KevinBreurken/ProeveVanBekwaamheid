using UnityEngine;
using System.Collections;

namespace Base.Game.Fish {
    
	public class SeaPositioning : MonoBehaviour {
	
	    private AreaController varsController;
	    private Area seaArea;

	    void Start() {
			
	        varsController = AreaController.Instance;
	        seaArea = varsController.seaField;

	    }

	    public void MovePosition(float _xPos) {
			
	        Vector2 ownPosition = transform.localPosition;
	        if (_xPos < 0) {
				
	            if (ownPosition.x <= seaArea.xLeft){ 
				} else {
					
	                transform.Translate(new Vector2(_xPos, 0));

	            }

	        } else {
				
	            if (ownPosition.x >= seaArea.xRight) {
				} else {
					
	                transform.Translate(new Vector2(_xPos, 0));

	            }

	        }

	    }
	
    }
    
}