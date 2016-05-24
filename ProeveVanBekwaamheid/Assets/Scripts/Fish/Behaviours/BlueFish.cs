using UnityEngine;
using System.Collections;

public class BlueFish : FishBehaviour
{
    public void Start()
    {
        speed = Random.Range(1, 10);
        ownStart();
    }

    void Update()
    {
        SwimDirection(ownDirection);
        OutOfBound();
    }

    public override void SetType()
    {
        base.SetType();
        requiredHookColor = HookColors.YELLOW;   
    }
}
