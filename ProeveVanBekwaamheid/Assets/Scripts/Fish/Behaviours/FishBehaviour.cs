﻿using UnityEngine;
using System.Collections;
using Chanisco;
using Base.Manager;
using BaseFrame.QAudio;
using DG.Tweening;
using Base.Game.Hooks;

namespace Base.Game.Fish {

	public class FishBehaviour : MonoBehaviour {

	    public QAudioObjectHolder rightSound;
	    public QAudioObjectHolder wrongSound;

	    public Direction ownDirection;
	    public bool caught;
	    public float speed = 5;
	    public float pullPressure;
	    public Area fishArea;
	    public FishPulls pullInformation;

	    public VisualEmotion emotion;
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
			
			wrongSound.CreateAudioObject();
			rightSound.CreateAudioObject();

	        spriteComponent = GetComponent<SpriteRenderer>();
	        isAnimating = false;
	        gameObject.tag = ownTag;

	    }

	    public void ownStart() {
			
	        SetType();
	        gameObject.SetActive(false);
	        ownInstinct.Init(this);
	        InMotion = true;

	        if (emotion == null)
	            emotion = GetComponentInChildren<VisualEmotion>();
	        
	    }

	    
	    public FishBehaviour GetFish() {
			
	        if (caught == false)
	            return this;
	        
	        return null;

	    }

	    public IEnumerator TemporaryPause(float _timeInSeconds) {
			
	        InMotion = false;

	        yield return new WaitForSeconds(_timeInSeconds);

	        InMotion = true;

	    }

	    public void FollowTarget(Transform _targetTransform,float _speed) {
			
	        transform.position = ChaniscoLib.SmoothVector2Step(transform.position, _targetTransform.position, _speed);

	    }

	    public void GainFish(bool _rightColor) {
			
	        if (_rightColor == true) {
				
	            ScoreManager.Instance.AddScore((int)pullInformation.rightPoints);
	            rightSound.GetAudioObject().Play();

	        } else {
				
	            ScoreManager.Instance.AddScore((int)pullInformation.wrongPoints);
	            wrongSound.GetAudioObject().Play();

	        }

	        gameObject.SetActive(false);
	        transform.localPosition = new Vector3(-5,0,0);

	    }

	    public void SwimDirection(Direction _targetDirection) {
			
	        if (InMotion == true) {
				
	            FlipCharacter();
	            if (_targetDirection == Direction.RIGHT) {
					
	                transform.Translate(0.0005f * speed, 0, 0);

	            } else if (_targetDirection == Direction.LEFT) {
					
	                transform.Translate(-0.0005f * speed, 0, 0);

	            }

	        }

	    }

	    public void OutOfBound() {
			
	        if(transform.localPosition.x > fishArea.xRight) {
				
	            gameObject.SetActive(false);

	        } else if(transform.localPosition.x < fishArea.xLeft) {
				
	            gameObject.SetActive(false);

	        }

	    }

	    public void ActivateFish(Vector2 _targetSpawnPosition) {
			
	        caught = false;
	        transform.localPosition = _targetSpawnPosition;
	        gameObject.SetActive(true);
	        gameObject.transform.localScale = new Vector3(0,0,0);
	        gameObject.transform.DOScale(1, spawnAnimationDuration).SetEase(spawnAnimationEaseType);

	    }

	    private void FlipCharacter() {

	        spriteComponent.flipX = (ownDirection == Direction.LEFT) ? true : false ;

	    }

	    public virtual void SetType() { }

	}

	[System.Serializable]
	public class FishPulls {
		
	    public float rightPressure;
	    public float wrongPressure;

	    public float rightPoints;
	    public float wrongPoints;

	    public FishPulls(float _rightPressure, float _wrongPressure,float _rightPoints,float _wrongPoints) {
			
	        this.rightPressure  = _rightPressure;
	        this.wrongPressure  = _wrongPressure;
	        this.rightPoints    = _rightPoints;
	        this.wrongPoints    = _wrongPoints;

	    }

	}

}


