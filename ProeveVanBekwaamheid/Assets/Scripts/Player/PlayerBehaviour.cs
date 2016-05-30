using UnityEngine;
using System.Collections;
using Chanisco;
using BaseFrame.QInput;
using Base.Game;
using Base.Game.Hooks;
using DG.Tweening;
using Base.Game.Fish;

/// <summary>
/// Contains classes that are not used anymore.
/// </summary>
namespace Deprecated {
	/*
	public class PlayerBehaviour : MonoBehaviour {

        /// <summary>
        /// The input required to do actions.
        /// </summary>
	    private BaseQInputMethod inputMethod;

        /// <summary>
        /// The speed that the player uses to move around the field.
        /// </summary>
	    public float speedFactor = 0.05f;

        /// <summary>
        /// Distance required between mouse and player.
        /// </summary>
		private float mouseMovementDistance = 0.3f;

        /// <summary>
        /// Original Vector2 position of the player
        /// </summary>
	    private Vector2 originalPos;

        /// <summary>
        /// The red hook behaviour.
        /// </summary>
	    public HookBehaviour redHook;

        /// <summary>
        /// The green hook behaviour.
        /// </summary>
        public HookBehaviour greenHook;


        /// <summary>
        /// The yellow hook behaviour.
        /// </summary>
        public HookBehaviour yellowHook;


        /// <summary>
        /// The speed the hook uses to return back to the field if nothing is grabbed.
        /// </summary>
        public float ownHookSpeed;

        /// <summary>
        /// The area the player can swim in.
        /// </summary>
	    private AreaController areaContorller;

        /// <summary>
        /// The area where the fishes spawn.
        /// </summary>
	    private Area fishArea;
	    
		//Input
	    public bool recievesPlayerInput;
	    private float movementInput;

	    void Update () { Controlls(); }
	    void FixedUpdate () { Movement(); }

	    void Awake () {

	        inputMethod = QInputManager.Instance.GetCurrentInputMethod();
	        QInputManager.Instance.onInputChanged += QInputManager_Instance_onInputChanged;

	    }

	    void QInputManager_Instance_onInputChanged (BaseQInputMethod _changedMethod) {

	        inputMethod = _changedMethod;

	    }

	    private void Start () {
			
	        areaContorller = AreaController.Instance;
	        originalPos = transform.localPosition;
	        fishArea = areaContorller.viewField;

	        redHook.releaseSpeed = ownHookSpeed;
	        greenHook.releaseSpeed = ownHookSpeed;
	        yellowHook.releaseSpeed = ownHookSpeed;

	    }
	   
		public void Load () {
			
			recievesPlayerInput = true;

	        //stops the re=centering.
			transform.DOKill();

		}

		public void Unload () {
			
			recievesPlayerInput = false;

		}

	    public void Recenter () {

            //Reset movement input
            movementInput = 0;

            //Get distance from center
            float distance = transform.position.x - originalPos.x;
	        distance = Mathf.Abs(distance);

			transform.DOLocalMove(originalPos, distance);

	    }

	    /// <summary>
	    /// All scripts that are called that are referenced to controll
	    /// </summary>
	    private void Controlls() {
			
			if(!recievesPlayerInput)
				return;

	        HookControlls();

	        //Get the movement controls
			Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

			mousePos.x -= 0.5f;

			if(mousePos.x < -mouseMovementDistance || mousePos.x > mouseMovementDistance) {
				
				movementInput = mousePos.x;

			} else {
				
				movementInput = Mathf.MoveTowards(movementInput,0,0.05f);

			}

	    }

	    private void Movement () {

	        transform.Translate(movementInput * speedFactor, 0, 0);
	        transform.position = new Vector2(Mathf.Clamp(transform.position.x, fishArea.xLeft, fishArea.xRight), transform.position.y);

	    }

	    /// <summary>
	    /// Calls to the Hookbehaviours to let the hooks go loose
	    /// </summary>
	    private void HookControlls() {
			
			if (inputMethod.GetRedHookInput()) {
				
	            redHook.ReleaseHook();

	        } else if (inputMethod.GetGreenHookInput()) {
				
	            greenHook.ReleaseHook();

	        } else if (inputMethod.GetYellowHookInput()) {
				
	            yellowHook.ReleaseHook();

	        }

	    }
			
	}
    */
}