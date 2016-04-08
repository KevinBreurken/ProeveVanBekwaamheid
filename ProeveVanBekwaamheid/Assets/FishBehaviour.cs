using UnityEngine;
using System.Collections;
using Chanisco;

public class FishBehaviour : MonoBehaviour {

    public void FollowTarget(Transform targetTransform)
    {
        transform.position = ChaniscoLib.SmoothVector2Step(transform.position, targetTransform.position, 0.4f);
    }

    public void GainFish()
    {
        Destroy(gameObject);
    }
}
