using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    private float speed = 0.1f;
    public Direction ownDirection;
    public HookBehaviour redHook;
    public HookBehaviour greenHook;
    public HookBehaviour blueHook;

    public void Update ()
    {
        Controlls();

    }

    private void Controlls()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed, 0, 0);
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
