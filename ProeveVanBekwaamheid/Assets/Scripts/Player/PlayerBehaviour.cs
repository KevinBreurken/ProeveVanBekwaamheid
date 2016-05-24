using UnityEngine;
using System.Collections;
using Chanisco;
using BaseFrame.QInput;
using Base.Game;
using DG.Tweening;

public class PlayerBehaviour : InGameObject {

    private BaseQInputMethod inputMethod;

    private float speedFactor = 0.05f;
	private float mouseMovementDistance = 0.3f;

    private Vector2 originalPos;

    public HookBehaviour redHook;
    public HookBehaviour greenHook;
    public HookBehaviour yellowHook;

    public float ownHookSpeed;


    private AreaController areaContorller;
    private Area fishArea;
    
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
   

	public override void Load ()
	{
		
		base.Load ();
		recievesPlayerInput = true;

        //stops the recentering.
		transform.DOKill();

	}

	public override void Unload ()
	{
		
		base.Unload ();
		recievesPlayerInput = false;

	}

    public void Recenter () {

        //Get distance from center
        float distance = transform.position.x - originalPos.x;
        distance = Mathf.Abs(distance);

		transform.DOLocalMove(originalPos, distance);

    }

    /// <summary>
    /// All scripts that are called that are referenced to controll
    /// </summary>
    private void Controlls()
    {
		
		if(!recievesPlayerInput)
			return;

        HookControlls();

        //Get the movement controls
		Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

		mousePos.x -= 0.5f;

		Debug.Log(mousePos);

		if(mousePos.x < -mouseMovementDistance || mousePos.x > mouseMovementDistance) {
			movementInput = mousePos.x;
		}else{
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
    private void HookControlls()
    {
		if (inputMethod.GetRedHookInput())
        {
            redHook.ReleaseHook();
        }
		else if (inputMethod.GetGreenHookInput())
        {
            greenHook.ReleaseHook();
        }
		else if (inputMethod.GetYellowHookInput())
        {
            yellowHook.ReleaseHook();
        }

    }


    private void OutOfBound() {

    }

}
