using UnityEngine;
using System.Collections;
using Base.Game.Hooks;
namespace Base.Game.Fish {
	
	public class GreenFish : FishBehaviour {

	    public void Start() {
			
	        speed = Random.Range(1, 20);
	        Init();

	    }

	    public void OnEnable() {
			
	        speed = Random.Range(1, 20);
	        InMotion = true;

	    }

	    void Update() {
			
	        SwimDirection(ownDirection);
	        OutOfBound();

	    }
        
	    public override void SetType() {
			
	        base.SetType();
            requiredHookColor = ColorEnum.GREEN;

	    }

	}

}
