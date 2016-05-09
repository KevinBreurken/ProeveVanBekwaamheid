using UnityEngine;
using System.Collections;

public class GreenFish : FishBehaviour {

    public void Start()
    {
        speed = Random.Range(1, 20);
        ownStart();
    }

    void Update()
    {
        SwimDirection(ownDirection);
        OutOfBound();
    }

    public override void GetType()
    {
        base.GetType();
        requiredHookColor = HookColors.GREEN;
    }
}
