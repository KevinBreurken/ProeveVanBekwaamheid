using UnityEngine;
using System.Collections;

public class YellowIntuition : FishInstinct {

    public override void ReactOnHook(Transform _target)
    {
        parent.speed += 10;
        StartCoroutine("SwimOpositeDirection");
    }
}
