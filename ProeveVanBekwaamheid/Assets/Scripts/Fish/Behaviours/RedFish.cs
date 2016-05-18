using UnityEngine;
using System.Collections;

public class RedFish : FishBehaviour {

    public void Start()
    {
        speed = Random.Range(20, 30);
        ownStart();
    }
    
    public void OnEnable()
    {
        speed = Random.Range(20, 30);
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
        requiredHookColor = HookColors.RED;
    }
}
