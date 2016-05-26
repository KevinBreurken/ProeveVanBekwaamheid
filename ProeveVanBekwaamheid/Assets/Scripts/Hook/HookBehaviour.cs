using UnityEngine;
using System.Collections;
using BaseFrame.QAudio;

namespace Base.Game.Hooks {
	
	public class HookBehaviour : MonoBehaviour {
		
		public FishBehaviour ownFish;
		public HookColors ownHookColor;

	    public bool hookReleased;
	    public bool hookPull;
	    public bool hookInteracted;

	    public float releaseSpeed;
		public float pullSpeed;

	    public QAudioObjectHolder chainSound;

	    private Vector2 OriginalPos;
	    private bool rightColor;
		private float seabottom;

	    private const string ownTag = "Hook";

	    void Awake () {
			
	        chainSound.CreateAudioObject();
	        gameObject.tag = ownTag;

	    }

	    public void hookStart() {
			
	        OriginalPos = transform.position;
	        SetType();
	        seabottom   = AreaController.Instance.viewField.yBottom + 1;

	    }

	    public void ReleaseHook() {
			
	        if(hookReleased == true)
	            return;
	        
	        chainSound.GetAudioObject().Play();
	        hookReleased = true;

	    }


	    public void hookUpdate() {
			
	        if (hookReleased == true) {
				
	            if (hookPull == true) {
					
	                if (ownFish != null) 
	                    ownFish.FollowTarget(transform, 0.9f);
				
	                
	                if (PullHook() == false) {
						
	                    OnHookReturned();
	                    hookPull = false;
	                    hookReleased = false;
	                    hookInteracted = false;

	                }

	            } else {
					
	                if (LooseHook() == false | hookInteracted == true) {
						
	                    hookPull = true;
	                    chainSound.GetAudioObject().Stop();
	                }

	            }

	        }

	    }

	    private void OnHookReturned() {
			
	        if (ownFish != null) {
				
	            ownFish.GainFish(rightColor);
	            ownFish = null;

	        }

	    }

	    public bool LooseHook() {
			
	        if (transform.position.y > seabottom) {
	            transform.Translate(0, -releaseSpeed, 0);
	            return true;

	        } else {
				
	            pullSpeed = releaseSpeed;
	            return false;

	        }

	    }

	    public bool PullHook() {
	        
	        if (transform.position.y < OriginalPos.y) {
				
	            transform.Translate(0, pullSpeed, 0);
	            return true;

	        } else {
				
	            return false;

	        }

	    }

	    void OnTriggerEnter2D(Collider2D other) {
			
	        if (other.tag == "Fish") {
				
	            if(ownFish == null) {
					
	                FishBehaviour tempFish = other.GetComponent<FishBehaviour>();
					if (tempFish.caught == false){
						
	                    if (isColorIdentical(tempFish.requiredHookColor)) {
							
	                        pullSpeed = tempFish.pullInformation.rightPressure;
	                        rightColor = true;

	                    } else {
							
	                        pullSpeed = tempFish.pullInformation.wrongPressure;
	                        rightColor = false;

	                    }

	                    ownFish = tempFish;
	                    ownFish.caught = true;
	                    hookInteracted = true;

	                }

	            }

	        }

	    }

		private bool isColorIdentical(HookColors _requiredColor) {
			
	        if(ownHookColor == _requiredColor)
	            return true;
	      
	        return false;
	        
	    }

	    public virtual void SetType() {

	    }

	}

	public enum HookColors {
		
	    RED,
	    YELLOW,
	    GREEN

	}

}