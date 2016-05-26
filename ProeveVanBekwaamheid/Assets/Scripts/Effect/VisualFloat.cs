using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace Deprecated {
	
	public class VisualFloat : MonoBehaviour {
		/*
		public FloatState currentFloatState;

	    public float magnitude;
	    private float originalYpos;
	    private float maxY;
	    private float minY;

	    void Start() {
			
	        if (magnitude < 0)
	            magnitude = 0.5f;
	        
	        originalYpos = transform.localPosition.y;
	        maxY = originalYpos + magnitude;
	        minY = originalYpos - magnitude;

	    }

		void Update () {
			
	        StartCoroutine(Float());

		}

	    IEnumerator Float() {
			
	        if (currentFloatState == FloatState.DOWN) {
				
	            if (transform.localPosition.y <= minY ) {
					
	                yield return new WaitForSeconds(0.3f);
	                currentFloatState = FloatState.UP;

	            } else {
					
	                transform.DOLocalMoveY(minY - 0.1f, 5);

	            }

	        } else if (currentFloatState == FloatState.UP) {
				
	            if (transform.localPosition.y >= maxY) {
					
	                yield return new WaitForSeconds(0.5f);
	                currentFloatState = FloatState.DOWN;

	            } else {
					
	                transform.DOLocalMoveY(maxY + 0.1f, 5);

	            }

	        }

	    }
		*/
	}

	public enum FloatState {
		
	    UP,
	    DOWN

	}

}