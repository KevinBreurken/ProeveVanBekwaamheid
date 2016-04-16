using UnityEngine;
using System.Collections;

public class SeaPositioning : MonoBehaviour {
    private Vector2 originalPos;

    void Start()
    {
        originalPos = transform.localPosition;
    }

    public void MovePosition(float Xpos)
    {
        transform.Translate(new Vector2(Xpos,0));
    }
}
