using UnityEngine;
using System.Collections;
using Chanisco;
using BaseFrame.QInput;
using Base.Game;
using DG.Tweening;

public class PlayerBehaviour : InGameObject {

	private BaseQInputMethod inputMethod;

    private float speedFactor     = 0.05f;
    private float maxSpeed  	  = 0.7f;
    private float minSpeed  	  = -0.5f;
    
	private float minXDistance = -10;
	private float maxXDistance = 10;

    private Vector2 originalPos;

    public HookBehaviour redHook;
    public HookBehaviour greenHook;
    public HookBehaviour yellowHook;

    public float ownHookSpeed;


    private AreaController areaContorller;
    private SeaController seaController;
    private Area fishArea;

    private float Xpos;
    private float borderPos;

	public bool recievesPlayerInput;

	void Awake () {
		
		inputMethod = QInputManager.Instance.GetCurrentInputMethod();
		QInputManager.Instance.onInputChanged += QInputManager_Instance_onInputChanged;

	}

	void QInputManager_Instance_onInputChanged (BaseQInputMethod _changedMethod) {
		
		inputMethod = _changedMethod;

	}

    private void Start()
    {
        areaContorller  = AreaController.Instance;
        seaController   = SeaController.Instance;
        originalPos     = transform.localPosition;
        fishArea        = areaContorller.viewField;

        redHook.releaseSpeed   = ownHookSpeed;
        greenHook.releaseSpeed = ownHookSpeed;
        yellowHook.releaseSpeed  = ownHookSpeed;
    }

    public void Update ()
    {
        Controlls();
    }

	public override void Load ()
	{
		
		base.Load ();
		recievesPlayerInput = true;

	}

	public override void Unload ()
	{
		
		base.Unload ();
		recievesPlayerInput = false;

	}

    public void Recenter () {

        transform.DOLocalMove(originalPos, 5);

    }

    /// <summary>
    /// All scripts that are called that are referenced to controll
    /// </summary>
    private void Controlls()
    {
		
		if(!recievesPlayerInput)
			return;
		
        HookControlls();
        BoatMovementControlls();

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

    /// <summary>
    /// Movement that the boat uses to move around the sea
    /// </summary>
    private void BoatMovementControlls()
    {
		float horizontalMovementInput = inputMethod.GetMovementInput().x;
		transform.Translate(horizontalMovementInput * speedFactor ,0,0);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x,fishArea.xLeft,fishArea.xRight),transform.position.y);

    }

    private void OutOfBound()
    {

    }

}
