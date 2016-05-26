using UnityEngine;
using System.Collections;

namespace Base.Game.FishSpawning {
	
	public class AreaController : Singleton<AreaController> {
		
	    public Area viewField;
	    public Area SeaField;

	    /// <summary>
	    /// DrawGizmo that shows the fields for the VarsController
	    /// </summary>
	    private void OnDrawGizmos() {
			
	        //Square for the FishArea
	        DrawSquare(viewField.xLeft, viewField.yTop, viewField.xRight, viewField.yBottom, Color.green);

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
		private void DrawSquare(float _left, float _top, float _right, float _bottom, Color _targetcolor) {
			
	        Gizmos.color = _targetcolor;
	        Gizmos.DrawLine(new Vector3(_left, _top),  new Vector3(_right, _top));
	        Gizmos.DrawLine(new Vector3(_right, _top), new Vector3(_right, _bottom));
	        Gizmos.DrawLine(new Vector3(_right, _bottom), new Vector3(_left, _bottom));
	        Gizmos.DrawLine(new Vector3(_left, _bottom),  new Vector3(_left, _top));

	    }


	}


	/// <summary>
	/// Object that determines a area with left,right,top and bottom position
	/// </summary>
	[System.Serializable]
	public class Area {
			
	    public float xLeft;
	    public float xRight;
	    public float yTop;
	    public float yBottom;

	    public Area(float _xLeft, float _xRight, float _yTop, float _yBottom) {
	        xLeft = _xLeft;
	        xRight = _xRight;
	        yTop = _yTop;
	        yBottom = _yBottom;

	    }

	}

}