﻿using UnityEngine;
using System.Collections;
using Chanisco;

public class FishBehaviour : MonoBehaviour {

    public Direction ownDirection;
    public bool caught;
    public float speed = 5;
    public float pullPressure;
    public Area fishArea;

    private Vector3 originalSize;


    public void ownStart()
    {
        originalSize = transform.localScale;
        gameObject.SetActive(false);
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

    public void FollowTarget(Transform targetTransform)
    {
        transform.position = ChaniscoLib.SmoothVector2Step(transform.position, targetTransform.position, 0.4f);
    }

    public void GainFish()
    {
        transform.localPosition = new Vector3(-5,0,0);
        gameObject.SetActive(false);
    }

    public void SwimDirection(Direction targetDirection)
    {
        FlipCharacter();
        if (targetDirection == Direction.RIGHT)
        {
            transform.Translate(0.005f * speed, 0, 0);
        }
        else if (targetDirection == Direction.LEFT)
        {
            transform.Translate(-0.005f * speed, 0, 0);
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
        if (ownDirection == Direction.LEFT)
        {
            transform.localScale = originalSize;
        }
        else if (ownDirection == Direction.RIGHT)
        {
            transform.localScale = new Vector3(-originalSize.x, originalSize.y, originalSize.z);
        }
    }
}

public class fishPulls
{
    public float rightPressure;
    public float wrongPressure;
    public fishPulls(float right, float wrong)
    {
        this.rightPressure = right;
        this.wrongPressure = wrong;
    }
}
