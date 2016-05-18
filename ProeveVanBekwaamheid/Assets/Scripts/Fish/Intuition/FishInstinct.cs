using UnityEngine;
using System.Collections;

public class FishInstinct : MonoBehaviour
{
    public FishBehaviour parent;
    public void Init(FishBehaviour _parent)
    {
        parent = _parent;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fish")
        {
            FishBehaviour tempFishBehaviour = other.gameObject.GetComponent<FishBehaviour>();
            ReactOnFish(tempFishBehaviour);
        }

        if (other.gameObject.tag == "Weed")
        {
            ReactOnWeed(other.transform);
        }

        if (other.gameObject.tag == "Hook")
        {
            ReactOnHook(other.transform);
        }

    }

    public virtual void ReactOnFish(FishBehaviour _target)
    {

    }

    public virtual void ReactOnWeed(Transform _target)
    {

    }

    public virtual void ReactOnHook(Transform _target)
    {

    }



    public IEnumerator SwimOpositeDirection()
    {
        parent.StartCoroutine("TemporaryPause", 0.5f);
        Direction solutionDirection;
        if (parent.ownDirection == Direction.LEFT)
        {
            solutionDirection = Direction.RIGHT;
        }
        else
        {
            solutionDirection = Direction.LEFT;
        }
        parent.ownDirection = solutionDirection;
        yield break;

    }
}
