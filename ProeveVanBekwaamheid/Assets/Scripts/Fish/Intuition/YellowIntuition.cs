using UnityEngine;
using System.Collections;

namespace Base.Game.Fish {
	
	public class YellowIntuition : FishInstinct {

	    public override void ReactOnHook(Transform _target)
	    {
	        parent.speed += 10;
	        parent.emotion.Emote(Emotions.SHOCK);
	        StartCoroutine("SwimOpositeDirection");
	    }
	}

}
