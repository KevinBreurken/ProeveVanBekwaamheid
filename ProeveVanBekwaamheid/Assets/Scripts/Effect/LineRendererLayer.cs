﻿using UnityEngine;
using System.Collections;

namespace Base.Effect {

	using UnityEngine;

	[RequireComponent (typeof (LineRenderer))]
	public class LineRendererLayer : MonoBehaviour {
		
		public string sortingLayer;
		public int sortingOrder;
		public GameObject lineEnd;
		private LineRenderer lineRenderer;

		void Awake () {

			lineRenderer = GetComponent<LineRenderer>();
            //Prevents modifying the material asset itself.
            lineRenderer.sharedMaterial = new Material(lineRenderer.sharedMaterial);
            
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

			lineRenderer.sharedMaterial.mainTextureScale = new Vector2(distance * 2.15f,1);

		}

	}

}
