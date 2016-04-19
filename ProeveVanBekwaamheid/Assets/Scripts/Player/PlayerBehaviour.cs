using UnityEngine;
using System.Collections;
using Chanisco;

public class PlayerBehaviour : MonoBehaviour {

    private float speed = 0.1f;
    public Direction ownDirection;
    private Vector2 originalPos;
    public HookBehaviour redHook;
    public HookBehaviour greenHook;
    public HookBehaviour blueHook;

    private VarsController varscontroller;
    private Area fishArea;

    private SeaController seaController;
    private float Xpos;

    private void Start()
    {
        varscontroller  = VarsController.Instance;
        seaController   = SeaController.Instance;
        originalPos     = transform.localPosition;
        fishArea        = varscontroller.fishField;
    }

    public void Update ()
    {
        Debug.Log(Xpos);
        Controlls();
    }

    private void Controlls()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(transform.localPosition.x > fishArea.xLeft)
            {
                Xpos = ChaniscoLib.AddWithMax(-Xpos,speed,1,0);
            }
            else
            {
                transform.localPosition = new Vector2(fishArea.xLeft, originalPos.y);
                seaController.MoveSea(speed);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.localPosition.x < fishArea.xRight)
            {
                   Xpos = ChaniscoLib.AddWithMax(Xpos, speed, 1, 0);
            }
            else
            {
                transform.localPosition = new Vector2(fishArea.xRight, originalPos.y);
                seaController.MoveSea(-speed);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            redHook.ReleaseHook();
        }
        else if(Input.GetKey(KeyCode.S))
        {
            greenHook.ReleaseHook();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            blueHook.ReleaseHook();
        }
    }

    private void BoatMovement()
    {

    }
}
