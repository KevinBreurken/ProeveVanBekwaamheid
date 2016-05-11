using UnityEngine;
using System.Collections;

public class RedIntuition : FishInstinct {

  
    public override void ReactOnFish(FishBehaviour _target)
    {
        if(_target.requiredHookColor == HookColors.RED)
        {
            if (_target.ownDirection != parent.ownDirection)
            {
                StartCoroutine("SwimOpositeDirection");
            }
        }
    }

    public IEnumerator SwimOpositeDirection()
    {
        parent.StartCoroutine("TemporaryPause",0.5f);
        Direction solutionDirection;
        if (parent.ownDirection == Direction.LEFT)
        {
            solutionDirection = Direction.RIGHT;
        }
        else
        {
            solutionDirection = Direction.LEFT;
        }
        parent.ownDirection = solutionDirection;
        yield break;

    }


}
