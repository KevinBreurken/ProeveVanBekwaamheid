using UnityEngine;
using System.Collections;

public class GreenFish : FishBehaviour {

    public void Start()
    {
        speed = Random.Range(1, 20);
        ownStart();
    }

    public void OnEnable()
    {
        speed = Random.Range(1, 20);
        InMotion = true;
    }

    void Update()
    {
        SwimDirection(ownDirection);
        OutOfBound();
    }

    public override void SetType()
    {
        base.SetType();
        requiredHookColor = HookColors.GREEN;
    }
}
