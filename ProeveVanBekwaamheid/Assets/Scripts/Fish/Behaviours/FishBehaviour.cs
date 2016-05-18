using UnityEngine;
using System.Collections;
using Chanisco;
using Base.Manager;
using BaseFrame.QAudio;
using DG.Tweening;

public class FishBehaviour : MonoBehaviour {

    public QAudioObjectHolder rightSound;
    public QAudioObjectHolder wrongSound;

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

    [Header("Graphic")]
    public Ease spawnAnimationEaseType = Ease.OutBack;
    public float spawnAnimationDuration = 1;
    private SpriteRenderer spriteComponent;
    
    private bool isAnimating;
    private const string ownTag = "Fish";

    void Awake () {
        spriteComponent = GetComponent<SpriteRenderer>();
        wrongSound.CreateAudioObject();
        rightSound.CreateAudioObject();
        isAnimating = false;
        gameObject.tag = ownTag;
    }
    public void ownStart()
    {
        originalSize = transform.localScale;
        SetType();
        gameObject.SetActive(false);
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
            rightSound.GetAudioObject().Play();
        }
        else
        {
            ScoreManager.Instance.AddScore((int)pullInformation.wrongPoints);
            wrongSound.GetAudioObject().Play();
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
        gameObject.transform.localScale = new Vector3(0,0,0);
        gameObject.transform.DOScale(1, spawnAnimationDuration).SetEase(spawnAnimationEaseType);
    }

    private void FlipCharacter()
    {

        spriteComponent.flipX = (ownDirection == Direction.LEFT) ? true : false ;

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


