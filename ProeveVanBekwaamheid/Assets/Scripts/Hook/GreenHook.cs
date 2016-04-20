using UnityEngine;
using System.Collections;

public class GreenHook : HookBehaviour {
    public LineRenderer Chain;
    private Transform ChainHolder;

    void Start()
    {
        ChainHolder = Chain.transform;
        hookStart();
    }

    void Update()
    {
        Debug.Log("Chainholder = " + ChainHolder.position);
        Chain.SetPosition(0, new Vector3(ChainHolder.position.x, ChainHolder.position.y, -0.1f));
        Chain.SetPosition(1, new Vector3(transform.position.x,transform.position.y + 0.2f, -0.1f));
        hookUpdate();
    }

    public override void SetType()
    {
        ownHookColor = HookColors.GREEN;
        base.SetType();
    }

    private Vector3 TurnZOff(Vector3 targetVector,float targetZ)
    {
        Vector3 solution;
        solution = new Vector3(targetVector.x,targetVector.y,targetZ);
        return solution;
    }

}
