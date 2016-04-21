using UnityEngine;
using System.Collections;

public class HookVisual : MonoBehaviour {
    private float previousXpos;

    void Start()
    {
        StartCoroutine("CheckPreviousPosition");
    }

    /// <summary>
    /// Check the previous position of the character and remember that position.
    /// The difference between position shows what direction they are looking at
    /// </summary>
    /// <returns></returns>
    IEnumerator CheckPreviousPosition()
    {
        previousXpos = transform.position.x;
        yield return new WaitForEndOfFrame();
        if (previousXpos == transform.position.x)
        {
            transform.eulerAngles = Vector3.zero;
        }
        if (previousXpos < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0,0,-20);
        }
        else if(previousXpos > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0,20);
        }
        StartCoroutine("CheckPreviousPosition");
    }
}
