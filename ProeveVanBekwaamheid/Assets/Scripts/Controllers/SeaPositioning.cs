using UnityEngine;
using System.Collections;

public class SeaPositioning : MonoBehaviour {
    private VarsController varsController;
    private Area seaArea;

    void Start()
    {
        varsController = VarsController.Instance;
        seaArea = varsController.SeaField;
    }

    public void MovePosition(float Xpos)
    {
        Vector2 ownPosition = transform.localPosition;
        if (Xpos < 0)
        {
            if (ownPosition.x <= seaArea.xLeft)
            {

            }
            else
            {
                transform.Translate(new Vector2(Xpos, 0));

            }
        }
        else
        {
            if (ownPosition.x >= seaArea.xRight)
            {

            }
            else
            {
                transform.Translate(new Vector2(Xpos, 0));

            }
        }
    }
}
