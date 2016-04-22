using UnityEngine;
using System.Collections;

namespace Base.Effect{

	using UnityEngine;

	[RequireComponent (typeof (LineRenderer))]
	[ExecuteInEditMode]
	public class LineRendererLayer : MonoBehaviour
	{
		public string sortingLayer;
		public int sortingOrder;

		private Renderer getMeshRenderer()
		{
			return gameObject.GetComponent<Renderer>();
		}

		void Update()
		{
			if(getMeshRenderer().sortingLayerName != sortingLayer && sortingLayer != ""){
				Debug.Log("Forcing sorting layer: "+sortingLayer);
				getMeshRenderer().sortingLayerName = sortingLayer;
				getMeshRenderer().sortingOrder = sortingOrder;
			}
		}
	}

}
