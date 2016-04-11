using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    private float speed = 0.1f;
    public Direction ownDirection;
    private Vector2 originalPos;
    public HookBehaviour redHook;
    public HookBehaviour greenHook;
    public HookBehaviour blueHook;
    
    private Area fishArea;

    private void Start()
    {
        originalPos = transform.localPosition;
        fishArea = VarsController.Instance.fishField;
    }

    public void Update ()
    {
        Controlls();
    }

    private void Controlls()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(transform.localPosition.x > fishArea.xLeft)
            {
                transform.Translate(-speed, 0, 0);
            }
            else
            {
                transform.localPosition = new Vector2(fishArea.xLeft, originalPos.y);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.localPosition.x < fishArea.xRight)
            {
                transform.Translate(speed, 0, 0);
            }
            else
            {
                transform.localPosition = new Vector2(fishArea.xRight, originalPos.y);
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
}
