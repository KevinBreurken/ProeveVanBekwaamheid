using UnityEngine;
using System.Collections;

namespace Base.Game.Fish {
	
	public class GreenIntuition : FishInstinct {

	    public Transform housing;
	    public override void ReactOnFish(FishBehaviour _target) {

	    }

	    public override void ReactOnWeed(Transform _target) {
			
	        HousingBase tempHouse = _target.GetComponent<HousingBase>();
	        parent.emotion.Emote(Emotions.SHOCK);

	        if (tempHouse.occupied == false) {
				
	            tempHouse.ClaimOwnership(this);
	            housing = _target;
	            StartCoroutine("HideBehindWeed");

	        }

	        base.ReactOnWeed(_target);

	    }

	    public IEnumerator HideBehindWeed() {
			
	        Transform parentTransform = parent.gameObject.transform;
	        float Distance = Vector2.Distance(parentTransform.position, housing.position);
	        if (Distance > 0.1f) {
				
	            parent.FollowTarget(housing,0.1f);
	            yield return new WaitForEndOfFrame();
	            StartCoroutine("HideBehindWeed");
	            parent.InMotion = false;
	            yield break;

	        } else {
				
	            yield break;

	        }

	    }

	}

}
