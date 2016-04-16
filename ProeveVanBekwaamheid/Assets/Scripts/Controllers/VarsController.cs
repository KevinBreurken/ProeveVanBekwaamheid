using UnityEngine;
using System.Collections;

public class VarsController : Singleton<VarsController> {
    public Area fishField;
    public Area SeaField;

    /// <summary>
    /// DrawGizmo that shows the fields for the VarsController
    /// </summary>
    private void OnDrawGizmos()
    {
        //Square for the FishArea
        DrawSquare(fishField.xLeft, fishField.yTop, fishField.xRight,fishField.yBottom, Color.green);

        //Square for the FishArea
        DrawSquare(SeaField.xLeft, SeaField.yTop, SeaField.xRight, SeaField.yBottom, Color.blue);

    }

    /// <summary>
    /// Makes a 2D square for drawGizmo using drawlines
    /// </summary>
    /// <param name="left">the left border of the square</param>
    /// <param name="top">the top border of the square</param>
    /// <param name="right">the right border of the square</param>
    /// <param name="bot">the bottom border of the square</param>
    /// <param name="targetcolor">The requisted color for the square</param>
    private void DrawSquare(float left, float top, float right, float bot, Color targetcolor)
    {
        Gizmos.color = targetcolor;
        Gizmos.DrawLine(new Vector3(left, top),  new Vector3(right, top));
        Gizmos.DrawLine(new Vector3(right, top), new Vector3(right, bot));
        Gizmos.DrawLine(new Vector3(right, bot), new Vector3(left, bot));
        Gizmos.DrawLine(new Vector3(left, bot),  new Vector3(left, top));

    }


}



[System.Serializable]
public class Area
{
    public float xLeft;
    public float xRight;
    public float yTop;
    public float yBottom;

    public Area(float XLeft, float XRight, float YTop, float YBottom)
    {
        xLeft = XLeft;
        xRight = XRight;
        yTop = YTop;
        yBottom = YBottom;

    }
}