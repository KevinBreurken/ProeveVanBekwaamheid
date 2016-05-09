using UnityEngine;
using System.Collections;

namespace Base.Game {

    public class CameraController : MonoBehaviour {

        public delegate void CameraEvent ();

        /// <summary>
        /// Called when the Camera is scrolling.
        /// </summary>
        public event CameraEvent onCameraScrolled;

        [Header("Target")]
        public bool followTarget;
        public Transform target;

        [Header("Positioning")]
        public Vector3 offset;
        public float cameraFollowDistance;

        [HideInInspector]
        public Camera gameViewCamera;

        private GameObject cameraLookPoint;
        private float verticalPostion;
        private Vector3 velocity = Vector3.zero;

        // Use this for initialization
        void Awake () {

            gameViewCamera = GetComponent<Camera>();
            cameraLookPoint = new GameObject();
            cameraLookPoint.hideFlags = HideFlags.HideInHierarchy;
            verticalPostion = transform.position.y;

        }

        /// <summary>
        /// Refocuses the target.
        /// </summary>
        public void RefocusTarget () {

            followTarget = true;

        }

        // Movement is done in fixedUpdate to prevent stuttering.
        void LateUpdate () {

            if (followTarget) {

                Vector3 point = gameViewCamera.WorldToViewportPoint(cameraLookPoint.transform.position);
                Vector3 delta = cameraLookPoint.transform.position - gameViewCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
                Vector3 destination = transform.position + delta + offset;

                float distance = transform.position.x - target.position.x;
                distance = Mathf.Abs(distance);
                Debug.Log(distance);
                Vector3 newPosition = Vector3.SmoothDamp(transform.position, destination, ref velocity, 4 - distance);
                transform.position = new Vector3(newPosition.x, transform.position.y, transform.position.z);

                if (target.transform.position.x != cameraLookPoint.transform.position.x) {

                    cameraLookPoint.transform.position = new Vector3(target.transform.position.x, target.transform.position.y,target.transform.position.z);

                }

            }

            if (onCameraScrolled != null) {

                onCameraScrolled();

            }

        }

    }

}