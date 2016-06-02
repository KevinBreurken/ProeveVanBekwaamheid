using UnityEngine;
using System.Collections;

namespace Base.Game {

    /// <summary>
    /// Controls the camera.
    /// </summary>
    public class CameraController : MonoBehaviour {

        public delegate void CameraEvent ();

        /// <summary>
        /// Called when the Camera is scrolling.
        /// </summary>
        public event CameraEvent onCameraScrolled;

        /// <summary>
        /// If the camera is currently following it's target.
        /// </summary>
        [Header("Target")]
        public bool followTarget;

        /// <summary>
        /// The target the camera is following.
        /// </summary>
        public Transform target;

        /// <summary>
        /// Reference to the game view camera.
        /// </summary>
        [HideInInspector]
        public Camera gameViewCamera;

        /// <summary>
        /// How fast the camera moves.
        /// </summary>
        public float movementSpeed = 0.5f;

        private GameObject cameraLookPoint;
        private Vector3 velocity = Vector3.zero;


        void Awake () {

            gameViewCamera = GetComponent<Camera>();

            cameraLookPoint = new GameObject();
            cameraLookPoint.hideFlags = HideFlags.HideInHierarchy;

        }

       
        void FixedUpdate () {

            if (followTarget) {

                Vector3 point = gameViewCamera.WorldToViewportPoint(cameraLookPoint.transform.position);
                Vector3 delta = cameraLookPoint.transform.position - gameViewCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
                Vector3 destination = transform.position + delta;

                //Get the distance between the camera's position and it's target.
                float distance = transform.position.x - target.position.x;
                distance = Mathf.Abs(distance);

                //Dampen the movement
                Vector3 newPosition = Vector3.SmoothDamp(transform.position, destination, ref velocity, movementSpeed);
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