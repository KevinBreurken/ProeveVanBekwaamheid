using UnityEngine;
using System.Collections;

public class HousingBase : MonoBehaviour {
    public bool occupied;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fish")
        {

        }
    }

    public void ClaimOwnership(FishInstinct target)
    {
        occupied = true;
    }

    public void LoseOwnership()
    {
        occupied = false;
    }
}
