using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace Base.Effect {

    /// <summary>
    /// A simple Sine movement effect on the Y axis.
    /// </summary>
    public class SineMovement : MonoBehaviour {

        public float frequency = 20.0f;  // Speed of sine movement
        public float magnitude = 0.5f;   // Size of sine movement
        private Vector3 axis;

        private Vector3 pos;

        void Start () {

            pos = transform.position;
            axis = transform.up;  // May or may not be the axis you want

        }

        void Update () {

            transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;

        }

    }

}