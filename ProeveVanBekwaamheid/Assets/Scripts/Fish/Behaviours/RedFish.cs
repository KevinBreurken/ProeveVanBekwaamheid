using UnityEngine;
using System.Collections;

public class RedFish : FishBehaviour {

    public void Start()
    {
        speed = Random.Range(20, 30);
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
        requiredHookColor = HookColors.RED;
    }
}
