using UnityEngine;
using System.Collections;
using Chanisco;

public class PlayerBehaviour : MonoBehaviour {

    private float speed     = 0.01f;
    private float maxSpeed  = 0.5f;
    private float minSpeed  = -0.5f;
    
    private Vector2 originalPos;

    public HookBehaviour redHook;
    public HookBehaviour greenHook;
    public HookBehaviour blueHook;

    private VarsController varscontroller;
    private SeaController seaController;
    private Area fishArea;

    private float Xpos;
    private float borderPos;

    private void Start()
    {
        varscontroller  = VarsController.Instance;
        seaController   = SeaController.Instance;
        originalPos     = transform.localPosition;
        fishArea        = varscontroller.fishField;
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
        if (Input.GetKey(KeyCode.A))
        {
            redHook.ReleaseHook();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            greenHook.ReleaseHook();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            blueHook.ReleaseHook();
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
