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



}
