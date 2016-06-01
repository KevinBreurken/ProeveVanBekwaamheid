using UnityEngine;
using System.Collections;

namespace Base.Game.Fish {

    /// <summary>
    /// Defines how the green fish behaves.
    /// </summary>
    public class YellowIntuition : FishInstinct {

	    public override void ReactOnHook(Transform _target)
	    {
            if(parent.currentSpeed < 20)
            parent.currentSpeed += 10;
	        parent.emotion.Emote(Emotions.SHOCK);
	        StartCoroutine("SwimOpositeDirection");
	    }
	}

}
