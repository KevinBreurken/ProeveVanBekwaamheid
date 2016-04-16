using UnityEngine;
using System.Collections;

public class BlueFish : FishBehaviour
{
    public void Start()
    {
        speed = Random.Range(1, 10);
        gameObject.SetActive(false);
    }

    void Update()
    {
        SwimDirection(ownDirection);
        OutOfBound();
    }
}
