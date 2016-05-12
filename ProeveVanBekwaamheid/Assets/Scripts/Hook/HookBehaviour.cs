using UnityEngine;
using System.Collections;
using BaseFrame.QAudio;

public class HookBehaviour : MonoBehaviour {

    public bool hookReleased;
    public bool hookPull;
    public bool hookInteracted;

    public float releaseSpeed;
    public float pullSpeed;

    private float seabottom;
    public FishBehaviour ownFish;

    public QAudioObjectHolder chainSound;

    private Vector2 OriginalPos;
    private bool rightColor;

    public HookColors ownHookColor;

    void Awake () {
        chainSound.CreateAudioObject();
    }

    public void hookStart()
    {
        OriginalPos = transform.position;
        SetType();
        seabottom   = AreaController.Instance.viewField.yBottom + 1;
    }

    public void ReleaseHook()
    {
        if(hookReleased == true)
        {
            return;
        }
        chainSound.GetAudioObject().Play();
        hookReleased = true;
    }


    public void hookUpdate()
    {
        if (hookReleased == true)
        {
            if (hookPull == true)
            {
                if (ownFish != null)
                {
                    ownFish.FollowTarget(transform, 0.9f);
                }
                if (PullHook() == false)
                {
                    OnHookReturned();
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
                    chainSound.GetAudioObject().Stop();
                }
            }
        }
    }

    private void OnHookReturned()
    {
        if (ownFish != null)
        {
            ownFish.GainFish(rightColor);
            ownFish = null;
        }
    }

    public bool LooseHook()
    {
        if (transform.position.y > seabottom)
        {
            transform.Translate(0, -releaseSpeed, 0);
            return true;
        }
        else
        {
            pullSpeed = releaseSpeed;
            return false;
        }
    }

    public bool PullHook()
    {
        
        if (transform.position.y < OriginalPos.y)
        {
            transform.Translate(0, pullSpeed, 0);
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
                    if (isColorIdentical(tempFish.requiredHookColor))
                    {
                        pullSpeed = tempFish.pullInformation.rightPressure;
                        rightColor = true;
                    }
                    else
                    {
                        pullSpeed = tempFish.pullInformation.wrongPressure;
                        rightColor = false;
                    }
                    ownFish = tempFish;
                    ownFish.caught = true;
                    hookInteracted = true;
                }
            }
        }
    }

    private bool isColorIdentical(HookColors requiredColor)
    {
        if(ownHookColor == requiredColor)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual void SetType()
    {

    }
}

public enum HookColors
{
    RED,
    BLUE,
    GREEN
}