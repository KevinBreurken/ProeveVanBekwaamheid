using UnityEngine;
using System.Collections;

public class GreenFish : FishBehaviour {

    public void Start()
    {
        speed = Random.Range(1, 50);
    }

    void Update()
    {
        SwimDirection(Direction.RIGHT);
    }

}
