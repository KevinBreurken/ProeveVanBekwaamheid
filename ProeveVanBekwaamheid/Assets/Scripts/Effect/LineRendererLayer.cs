using UnityEngine;
using System.Collections;

namespace Base.Effect {

	using UnityEngine;

	[RequireComponent (typeof (LineRenderer))]
	[ExecuteInEditMode]
	public class LineRendererLayer : MonoBehaviour {
		
		public string sortingLayer;
		public int sortingOrder;
		public GameObject lineEnd;
		private LineRenderer lineRenderer;

		void Awake () {
			lineRenderer = GetComponent<LineRenderer>();
		}

		private Renderer getMeshRenderer() {
			
			return gameObject.GetComponent<Renderer>();

		}

		void Update() {
			
			if(getMeshRenderer().sortingLayerName != sortingLayer && sortingLayer != ""){
				
				Debug.Log("Forcing sorting layer: "+ sortingLayer );
				getMeshRenderer().sortingLayerName = sortingLayer;
				getMeshRenderer().sortingOrder = sortingOrder;

			}

			float distance = transform.position.y - lineEnd.transform.position.y;
			//TODO Fix error.
			lineRenderer.material.mainTextureScale = new Vector2(distance * 2.15f,1);

		}

	}

}
