using UnityEngine;
using System.Collections;
using DG.Tweening;

public class VisualFloat : MonoBehaviour {
    public float magnitude;
    private float originalYpos;
    private float maxY;
    private float minY;

    public FloatState currentFloatState;
    void Start()
    {
        if (magnitude < 0.5f)
        {
            magnitude = 0.5f;
        }
        originalYpos = transform.localPosition.y;
        maxY = originalYpos + magnitude;
        minY = originalYpos - magnitude;

    }
	void Update () {
        Float();
	}

    void Float()
    {
        if (currentFloatState == FloatState.DOWN)
        {
            Debug.Log("Bite me " + transform.localPosition.y + ", " + minY);
            if (transform.localPosition.y <= minY )
            {
                currentFloatState = FloatState.UP;
            }
            else
            {
                transform.DOLocalMoveY(minY - 0.1f, 1);
            }
        }
        else if (currentFloatState == FloatState.UP)
        {

            if (transform.localPosition.y < maxY)
            {
                transform.DOMoveY(maxY - 0.1f, 1);
            }
            else
            {
                currentFloatState = FloatState.DOWN;
            }

        }
    }
    
}

public enum FloatState
{
    UP,
    DOWN
}