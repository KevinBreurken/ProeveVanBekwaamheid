using UnityEngine;
using System.Collections;

public class RedFish : FishBehaviour {

    public void Start()
    {
        speed = Random.Range(20, 30);
    }

    void Update()
    {
        SwimDirection(Direction.RIGHT);
    }

}
