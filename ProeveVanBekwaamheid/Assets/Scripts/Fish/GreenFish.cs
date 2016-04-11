using UnityEngine;
using System.Collections;

public class GreenFish : FishBehaviour {

    public void Start()
    {
        speed = Random.Range(1, 20);
        gameObject.SetActive(false);
    }

    void Update()
    {
        SwimDirection(ownDirection);
    }

}
