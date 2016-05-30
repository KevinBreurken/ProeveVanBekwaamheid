using UnityEngine;
using System.Collections;

namespace Base.Game.Fish {
	
	public class FishInstinct : MonoBehaviour {
		
        /// <summary>
        /// The parent Fish class
        /// </summary>
	    public FishBehaviour parent;

        /// <summary>
        /// Init that sets the variables on start
        /// </summary>
        /// <param name="_parent"></param>
        public void Init(FishBehaviour _parent) {
			
	        parent = _parent;

	    }

        /// <summary>
        /// Checks with the colliders if we hit the target objects we can interact with
        /// </summary>
        /// <param name="other"></param>
	    void OnTriggerEnter2D(Collider2D other) {

            if (parent == null)
                return;

	        if (other.gameObject.tag == "Fish") {
				
	            FishBehaviour tempFishBehaviour = other.gameObject.GetComponent<FishBehaviour>();
	            ReactOnFish(tempFishBehaviour);

	        }

	        if (other.gameObject.tag == "Weed")
	            ReactOnWeed(other.transform);

	        if (other.gameObject.tag == "Hook")
	   			ReactOnHook(other.transform);
	      
	
	    }

        /// <summary>
        /// A reaction upon the fish you hit
        /// </summary>
        /// <param name="_target">The fish you hit</param>
	    public virtual void ReactOnFish(FishBehaviour _target) {

	    }

        /// <summary>
        /// A reaction upon the weed you hit
        /// </summary>
        /// <param name="_target">The weed you hit</param>
	    public virtual void ReactOnWeed(Transform _target) {

	    }

        /// <summary>
        /// A reaction upon the hook you hit
        /// </summary>
        /// <param name="_target">The hook you hit</param>
	    public virtual void ReactOnHook(Transform _target) {

	    }


        /// <summary>
        /// Function that makes the target swim the other direction
        /// </summary>
        /// <returns></returns>
	    public IEnumerator SwimOpositeDirection() {
			
	        parent.StartCoroutine("TemporaryPause", 0.5f);
			Direction solutionDirection;

	        if (parent.ownDirection == Direction.LEFT) {
				
	            solutionDirection = Direction.RIGHT;

	        } else {
				
	            solutionDirection = Direction.LEFT;

	        }

	        parent.ownDirection = solutionDirection;
	        yield break;

	    }

	}

}
