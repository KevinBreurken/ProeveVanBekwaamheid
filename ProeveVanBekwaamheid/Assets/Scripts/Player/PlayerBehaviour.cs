using UnityEngine;
using System.Collections;
using Chanisco;
using BaseFrame.QInput;

public class PlayerBehaviour : MonoBehaviour {

	private BaseQInputMethod inputMethod;

    private float speed     = 0.03f;
    private float maxSpeed  = 0.7f;
    private float minSpeed  = -0.5f;
    
    private Vector2 originalPos;

    public HookBehaviour redHook;
    public HookBehaviour greenHook;
    public HookBehaviour yellowHook;

    public float ownHookSpeed;


    private AreaController varscontroller;
    private SeaController seaController;
    private Area fishArea;

    private float Xpos;
    private float borderPos;

	void Awake () {
		
		inputMethod = QInputManager.Instance.GetCurrentInputMethod();
		QInputManager.Instance.onInputChanged += QInputManager_Instance_onInputChanged;

	}

	void QInputManager_Instance_onInputChanged (BaseQInputMethod _changedMethod)
	{
		
		inputMethod = _changedMethod;

	}

    private void Start()
    {
        varscontroller  = AreaController.Instance;
        seaController   = SeaController.Instance;
        originalPos     = transform.localPosition;
        fishArea        = varscontroller.fishField;

        redHook.releaseSpeed   = ownHookSpeed;
        greenHook.releaseSpeed = ownHookSpeed;
        yellowHook.releaseSpeed  = ownHookSpeed;
    }

    public void Update ()
    {
        Controlls();
    }

    /// <summary>
    /// All scripts that are called that are referenced to controll
    /// </summary>
    private void Controlls()
    {
        HookControlls();
        BoatMovementControlls();
    }

    /// <summary>
    /// the calls to the Hookbehaviours to let the hooks go loose
    /// </summary>
    private void HookControlls()
    {
		
		Vector2 movementInput = inputMethod.GetMovementInput();
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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.localPosition.x > fishArea.xLeft)
            {
                Xpos = ChaniscoLib.AddWithMax(Xpos, -speed, maxSpeed, minSpeed);
                borderPos = Xpos;
            }
            else
            {
                Xpos = 0;
                transform.localPosition = new Vector2(fishArea.xLeft, originalPos.y);
                seaController.MoveSea(-borderPos);
                borderPos = ChaniscoLib.AddWithMax(borderPos, -speed, maxSpeed, minSpeed);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.localPosition.x < fishArea.xRight)
            {
                Xpos = ChaniscoLib.AddWithMax(Xpos, speed, maxSpeed, minSpeed);
                borderPos = Xpos;
            }
            else
            {
                Xpos = 0;
                transform.localPosition = new Vector2(fishArea.xRight, originalPos.y);
                seaController.MoveSea(-borderPos);
                borderPos = ChaniscoLib.AddWithMax(borderPos, speed, maxSpeed, minSpeed);
            }
        }
        if (transform.localPosition.x >= fishArea.xRight)
        {
            transform.localPosition = new Vector2(fishArea.xRight, originalPos.y);
            seaController.MoveSea(-borderPos);
        }
        else if (transform.localPosition.x <= fishArea.xLeft)
        {
            transform.localPosition = new Vector2(fishArea.xLeft, originalPos.y);
            seaController.MoveSea(-borderPos);
        }
        Xpos = Mathf.SmoothStep(Xpos, 0, 0.2f);
        borderPos = Mathf.SmoothStep(borderPos, 0, 0.25f);
        
        transform.Translate(Xpos,0,0);
    }
}
