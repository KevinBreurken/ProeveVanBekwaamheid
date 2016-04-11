using UnityEngine;
using System.Collections;

public class VarsController : Singleton<VarsController> {
    public Area fishField;

    void OnDrawGizmos()
    {
        DrawSquare(fishField.xLeft, fishField.yTop, fishField.xRight,fishField.yBottom + fishField.yTop, Color.green);
    }

    void DrawSquare(float left, float top, float right, float bot, Color targetcolor)
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