using UnityEngine;
using System.Collections;
using Base.Game.Fish;
using BaseFrame.QAudio;

/// <summary>
/// Contains hook related classes.
/// </summary>
namespace Base.Game.Hooks {

	/// <summary>
    /// The behaviour for the hook.
    /// </summary>
	public class HookBehaviour : MonoBehaviour {
		
        /// <summary>
        /// The fish you're holding in the hook.
        /// </summary>
		public FishBehaviour ownFish;

        /// <summary>
        /// Color of this hook.
        /// </summary>
		public ColorEnum ownHookColor;

        /// <summary>
        /// Check if the hook is being released.
        /// </summary>
	    public bool hookReleased;

        /// <summary>
        /// Check if the hook is being pulled.
        /// </summary>
	    public bool hookPull;

        /// <summary>
        /// Check if the hook interacted with an object.
        /// </summary>
	    public bool hookInteracted;

        /// <summary>
        /// Speed that the hook goes down the sea.
        /// </summary>
	    public float releaseSpeed;

        /// <summary>
        /// Speed that the hook returns back to its position.
        /// </summary>
		public float pullSpeed;

        /// <summary>
        /// Sounds of the chains loosing from the boat.
        /// </summary>
	    public QAudioObjectHolder chainSound;

        /// <summary>
        /// Original position of the hook.
        /// </summary>
	    private Vector2 originalPos;

        /// <summary>
        /// Check if the hook was the right color.
        /// </summary>
	    private bool isRightColor;

        /// <summary>
        /// Lowest Y-position of the sea.
        /// </summary>
		private float seabottom;

        /// <summary>
        /// The tag that the hook will be instantiated with.
        /// </summary>
	    private const string ownTag = "Hook";

	    void Awake () {
			
	        chainSound.CreateAudioObject();
	        gameObject.tag = ownTag;

	    }
        
        /// <summary>
        /// Init that sets the variables on start
        /// </summary>
	    public void Init() {
	        originalPos = transform.position;
	        SetType();
	        seabottom   = AreaController.Instance.viewField.yBottom;
            hookReleased = false;

        }

        /// <summary>
        /// Releases the hook away from the boat
        /// </summary>
	    public void ReleaseHook() {
	        if(hookReleased == true)
	            return;
            
            chainSound.GetAudioObject().Play();
            hookReleased = true;

	    }

        /// <summary>
        /// Update that keeps track of the position and state of the hook
        /// </summary>
	    public void HookUpdate() {
	        if (hookReleased == true) {
				
	            if (hookPull == true) {
					
	                if (ownFish != null) 
	                    ownFish.FollowTarget(transform, 0.9f);
				
	                
	                if (PullHook() == false) {

                        hookPull = false;
	                    hookReleased = false;
	                    hookInteracted = false;
                        OnHookReturned();

                    }

	            } else {
					
	                if (LooseHook() == false | hookInteracted == true) {
                        
                        hookPull = true;
	                    chainSound.GetAudioObject().Stop();
	                }

	            }

	        }

	    }

        /// <summary>
        /// On returning of the hook back to the boat
        /// </summary>
	    public virtual void OnHookReturned() {
			
	        if (ownFish != null) {
				
	            ownFish.GainFish(isRightColor);
	            ownFish = null;

	        }

	    }
        /// <summary>
        /// Loose the hook away from the boat
        /// </summary>
        /// <returns>returns true until you hit the seabottom</returns>
	    public virtual bool LooseHook() {

	        if (transform.position.y > seabottom) {
	            transform.Translate(0, -releaseSpeed, 0);
	            return true;

	        } else {
				
	            pullSpeed = releaseSpeed;
	            return false;

	        }

	    }

        /// <summary>
        /// Pull the hook back to the boat
        /// </summary>
        /// <returns></returns>
	    public virtual bool PullHook() {
	        
	        if (transform.position.y < originalPos.y) {
				
	            transform.Translate(0, pullSpeed, 0);
	            return true;

	        } else {
				
	            return false;

	        }

	    }

        /// <summary>
        /// Checks if the hook is in contact to the fishes or any other targeted object
        /// </summary>
        /// <param name="other"></param>
	    void OnTriggerEnter2D(Collider2D other) {
			
	        if (other.tag == "Fish") {
				
	            if(ownFish == null) {
					
	                FishBehaviour tempFish = other.GetComponent<FishBehaviour>();
					if (tempFish.caught == false && tempFish.GetFish(this) != null) {
                        ownFish = tempFish.GetFish(this);
                        if (isColorIdentical(tempFish.requiredHookColor)) {
							
	                        pullSpeed = tempFish.pullInformation.rightPressure;
	                        isRightColor = true;

	                    } else {
							
	                        pullSpeed = tempFish.pullInformation.wrongPressure;
	                        isRightColor = false;

	                    }

	                    ownFish.caught = true;
	                    hookInteracted = true;

	                }

	            }

	        }

	    }

        /// <summary>
        /// Checks if the hook is the same color as the targetObject
        /// </summary>
        /// <param name="_targetColor">the targetColor</param>
        /// <returns>return true if the color is identical</returns>
		private bool isColorIdentical(ColorEnum _targetColor) {
			
	        if(ownHookColor == _targetColor)
	            return true;
	      
	        return false;
	        
	    }

        public virtual void ShockHook() {

        }

        /// <summary>
        /// Sets the type of the fish according to the FishEnum
        /// </summary>
	    public virtual void SetType() {

	    }

	}

}