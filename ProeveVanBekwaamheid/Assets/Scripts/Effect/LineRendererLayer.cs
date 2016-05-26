﻿using UnityEngine;
using System.Collections;

namespace Base.Effect {

    /// <summary>
    /// Updates the graphic so it won't stretch.
    /// </summary>
	[RequireComponent (typeof (LineRenderer))]
	public class LineRendererLayer : MonoBehaviour {
		
        /// <summary>
        /// The other end of the line.
        /// </summary>
		public GameObject lineEnd;
        private LineRenderer lineRenderer;
        private float previousDistance;

		void Awake () {

			lineRenderer = GetComponent<LineRenderer>();

            //Prevents modifying the material asset itself.
            lineRenderer.sharedMaterial = new Material(lineRenderer.sharedMaterial);
            lineRenderer.sharedMaterial.name = "HookLine";

        }

		void Update() {

            //modifies the material of the line so the texture won't stretch.
            float distance = transform.position.y - lineEnd.transform.position.y;

            if (distance != previousDistance) {

                lineRenderer.sharedMaterial.mainTextureScale = new Vector2(distance * 2.15f, 1);
                lineRenderer.sharedMaterial.mainTextureOffset = new Vector2(distance * -2.15f, 1);

            }

            previousDistance = distance;

		}

	}

}
