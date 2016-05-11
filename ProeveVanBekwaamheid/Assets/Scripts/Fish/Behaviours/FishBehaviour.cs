using UnityEngine;
using System.Collections;
using Chanisco;
using Base.Manager;

public class FishBehaviour : MonoBehaviour {

    public Direction ownDirection;
    public bool caught;
    public float speed = 5;
    public float pullPressure;
    public Area fishArea;
    public fishPulls pullInformation;

    private Vector3 originalSize;
    public HookColors requiredHookColor;

    public FishInstinct ownInstinct;
    public bool InMotion;

    public void OnEnable()
    {
        InMotion = true;
    }
    public void ownStart()
    {
        originalSize = transform.localScale;
        SetType();
        gameObject.SetActive(false);
        if (ownInstinct == null)
        {
            ownInstinct = GetComponentInChildren<FishInstinct>();
        }
        ownInstinct.Init(this);
        InMotion = true;
    }

    
    public FishBehaviour GetFish()
    {
        if (caught == false)
        {
            return this;
        }
        else
        {
            return null;
        }
    }

    public IEnumerator TemporaryPause(float timeInSeconds)
    {
        InMotion = false;
        yield return new WaitForSeconds(timeInSeconds);
        InMotion = true;
    }

    public void FollowTarget(Transform targetTransform,float speed)
    {
        transform.position = ChaniscoLib.SmoothVector2Step(transform.position, targetTransform.position, speed);
    }

    public void GainFish(bool _rightColor)
    {
        if (_rightColor == true)
        {
            ScoreManager.Instance.AddScore((int)pullInformation.rightPoints);
        }
        else
        {
            ScoreManager.Instance.AddScore((int)pullInformation.wrongPoints);
        }
        gameObject.SetActive(false);
        transform.localPosition = new Vector3(-5,0,0);
    }

    public void SwimDirection(Direction targetDirection)
    {
        if (InMotion == true)
        {
            FlipCharacter();
            if (targetDirection == Direction.RIGHT)
            {
                transform.Translate(0.0005f * speed, 0, 0);
            }
            else if (targetDirection == Direction.LEFT)
            {
                transform.Translate(-0.0005f * speed, 0, 0);
            }
        }
    }

    public void OutOfBound()
    {
        if(transform.localPosition.x > fishArea.xRight)
        {
            gameObject.SetActive(false);
        }
        else if(transform.localPosition.x < fishArea.xLeft)
        {
            gameObject.SetActive(false);
        }
    }

    public void ActivateFish(Vector2 targetSpawnPosition)
    {
        caught = false;
        transform.localPosition = targetSpawnPosition;
        gameObject.SetActive(true);

    }

    private void FlipCharacter()
    {
        if (ownDirection == Direction.RIGHT)
        {
            transform.localScale = originalSize;
        }
        else if (ownDirection == Direction.LEFT)
        {
            transform.localScale = new Vector3(-originalSize.x, originalSize.y, originalSize.z);
        }
    }

    public virtual void SetType()
    {

    }

}

[System.Serializable]
public class fishPulls
{
    public float rightPressure;
    public float wrongPressure;

    public float rightPoints;
    public float wrongPoints;
    public fishPulls(float RightPressure, float WrongPressure,float RightPoints,float WrongPoints)
    {
        this.rightPressure  = RightPressure;
        this.wrongPressure  = WrongPressure;
        this.rightPoints    = RightPoints;
        this.wrongPoints    = WrongPoints;
    }
}


