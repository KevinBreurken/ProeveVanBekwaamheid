using UnityEngine;
using System.Collections;

namespace BaseFrame.QEffect.Effects {

	/// <summary>
	/// Applies a ContrastComponent to the targeted camera.
	/// </summary>
    public class ContrastSetter : MonoBehaviour {

        public Camera targetCamera;
        private ContrastComponent contrastComponent;

        void Start () {
           
            if(targetCamera == null) {

                Debug.LogError("ContrastSetter: no targetCamera selected.");

            } else {

                targetCamera.gameObject.AddComponent<ContrastComponent>();
                contrastComponent = targetCamera.gameObject.GetComponent<ContrastComponent>();

            }

        }

        public ContrastComponent GetContrastComponent () {

            return contrastComponent;

        }

    }

}