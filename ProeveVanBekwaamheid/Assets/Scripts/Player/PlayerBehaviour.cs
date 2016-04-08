using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    private float speed = 0.1f;
    public Direction ownDirection;
    public HookBehaviour ownHook;

	public void Update ()
    {
        Controlls();
        //FlipCharacter();

    }

    private void FlipCharacter()
    {
        if (ownDirection == Direction.LEFT)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (ownDirection == Direction.RIGHT)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    private void Controlls()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ownDirection = Direction.LEFT;
            transform.Translate(-speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ownDirection = Direction.RIGHT;
            transform.Translate(speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            ownHook.ReleaseHook();
        }
    }
}

public enum Direction
{
    LEFT,
    RIGHT
}
