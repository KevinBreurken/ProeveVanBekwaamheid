using UnityEngine;
using System.Collections;

public class HookBehaviour : MonoBehaviour {

    public bool hookReleased;
    public bool hookPull;
    public bool hookInteracted;

    private float seabottom;
    public FishBehaviour ownFish;

    private Vector2 OriginalPos;

    public void hookStart()
    {
        OriginalPos = transform.localPosition;
        seabottom = VarsController.Instance.fishField.yBottom;
    }

    public void ReleaseHook()
    {
        if(hookReleased == true)
        {
            return;
        }
        hookReleased = true;
    }


    public void hookUpdate()
    {
        if (hookReleased == true)
        {
            if (hookPull == true)
            {
                if (PullHook() == false)
                {
                    hookPull = false;
                    hookReleased = false;
                    hookInteracted = false;
                }
            }
            else
            {
                if (LooseHook() == false | hookInteracted == true)
                {
                    hookPull = true;
                }
            }
            if(ownFish != null)
            {
                ownFish.FollowTarget(transform);
            }
        }
        else
        {
            OnHookReturned();
        }
    }
    private void OnHookReturned()
    {
        if (ownFish != null)
        {
            ownFish.GainFish();
            ownFish = null;
        }
    }

    public bool LooseHook()
    {
        if (transform.localPosition.y > seabottom)
        {
            transform.Translate(0, -0.1f, 0);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool PullHook()
    {
        if (transform.localPosition.y < OriginalPos.y)
        {
            transform.Translate(0, 0.1f, 0);
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fish")
        {
            if(ownFish == null)
            {
                FishBehaviour tempFish = other.GetComponent<FishBehaviour>();
                if (tempFish.caught == true)
                {

                }
                else
                {
                    ownFish = tempFish;
                    ownFish.caught = true;
                    hookInteracted = true;
                }
            }
        }
    }
}
