using UnityEngine;
using System.Collections;

namespace Base.Game.Hooks {

	public class BlueHook : HookBehaviour {
		
	    public LineRenderer Chain;
	    private Transform ChainHolder;

	    void Start() {
			
	        ChainHolder = Chain.transform;
	        hookStart();

	    }

	    void Update() {
			
	        Chain.SetPosition(0, new Vector3(ChainHolder.position.x, ChainHolder.position.y, -0.1f));
	        Chain.SetPosition(1, new Vector3(transform.position.x, transform.position.y + 0.2f, -0.1f));
	        hookUpdate();

	    }

		/// <summary>
		/// See BaseClass function.
		/// </summary>
	    public override void SetType() {
			
	        ownHookColor = HookColors.YELLOW;
	        base.SetType();

	    }

	}

}