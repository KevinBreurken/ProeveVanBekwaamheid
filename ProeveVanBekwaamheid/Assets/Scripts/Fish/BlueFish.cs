using UnityEngine;
using System.Collections;

public class BlueFish : FishBehaviour
{
    public void Start()
    {
        speed = Random.Range(1, 10);
    }

    void Update()
    {
        SwimDirection(Direction.RIGHT);
    }
}
