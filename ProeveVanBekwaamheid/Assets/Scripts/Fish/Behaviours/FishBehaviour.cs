using UnityEngine;
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
	    public ColorEnum requiredHookColor;

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

	        spriteComponent = GetComponentInChildren<SpriteRenderer>();
	        isAnimating = false;
	        gameObject.tag = ownTag;

	    }

        /// <summary>
        /// Init that sets the variables on start
        /// </summary>
        public void Init() {
			
	        SetType();
	        gameObject.SetActive(false);
	        ownInstinct.Init(this);
	        InMotion = true;

	        if (emotion == null)
	            emotion = GetComponentInChildren<VisualEmotion>();
	        
	    }

	    /// <summary>
        /// Public function that returns the fish if the fish isn't caught yet
        /// </summary>
        /// <returns></returns>
	    public FishBehaviour GetFish(HookBehaviour _target) {

            if (RespondToHook(_target) == false) {
                if (caught == false)
                    return this;
            }

	        
	        return null;

	    }

        /// <summary>
        /// A temporary pause that waits a target amount of time
        /// </summary>
        /// <param name="_timeInSeconds">target amount of time to wait</param>
        /// <returns></returns>
	    public IEnumerator TemporaryPause(float _timeInSeconds) {
			
	        InMotion = false;

	        yield return new WaitForSeconds(_timeInSeconds);

	        InMotion = true;

	    }
        /// <summary>
        /// Follows a target object in the world
        /// </summary>
        /// <param name="_targetTransform">Target transform you follow</param>
        /// <param name="_speed">Amount of speed you work toward your goal</param>
	    public void FollowTarget(Transform _targetTransform,float _speed) {
			
	        transform.position = ChaniscoLib.SmoothVector2Step(transform.position, _targetTransform.position, _speed);

	    }

        /// <summary>
        ///If the fish gets heeled you gain the fish
        /// </summary>
        /// <param name="_rightColor">is true if your color is the same as the color of the hook</param>
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

        /// <summary>
        /// Fish swims toward the targetdirection
        /// </summary>
        /// <param name="_targetDirection">Direction the fish needs to swim to</param>
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
        /// <summary>
        /// If the fish swims out of bounds
        /// </summary>
	    public void OutOfBound() {
			
	        if(transform.localPosition.x > fishArea.xRight) {
				
	            gameObject.SetActive(false);

	        } else if(transform.localPosition.x < fishArea.xLeft) {
				
	            gameObject.SetActive(false);

	        }

	    }

        /// <summary>
        /// The fish becomes active at the targetspawnposition 
        /// </summary>
        /// <param name="_targetSpawnPosition">Position where fish spawns</param>
	    public void ActivateFish(Vector2 _targetSpawnPosition) {
			
	        caught = false;
	        transform.localPosition = _targetSpawnPosition;
	        gameObject.SetActive(true);
	        gameObject.transform.localScale = new Vector3(0,0,0);
	        gameObject.transform.DOScale(1, spawnAnimationDuration).SetEase(spawnAnimationEaseType);

	    }

        /// <summary>
        /// Flips the character to their assigned direction 
        /// </summary>
	    private void FlipCharacter() {

	        spriteComponent.flipX = (ownDirection == Direction.LEFT) ? true : false ;

	    }
        /// <summary>
        /// Responce toward the hook
        /// </summary>
        public virtual bool RespondToHook(HookBehaviour _target) {
            return false;
        }

        /// <summary>
        /// Sets the type of the fish according to the FishEnum
        /// </summary>
        public virtual void SetType() { }


	}

    /// <summary>
    /// The stats that determine the speed and the score for the wrong and right color identity
    /// </summary>
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


