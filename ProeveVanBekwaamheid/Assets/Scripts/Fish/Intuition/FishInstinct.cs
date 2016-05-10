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

        }

    }

    public virtual void ReactOnFish(FishBehaviour _target)
    {
        
    }

}
