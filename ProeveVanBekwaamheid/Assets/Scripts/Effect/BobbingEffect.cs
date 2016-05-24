using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace Base.Effect {

    /// <summary>
    /// A simple bobbing movement effect on the Y axis to simulate water.
    /// </summary>
    public class BobbingEffect : MonoBehaviour {

        public float duration;
        public AnimationCurve curve;

        void Start () {

            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            transform.DOMoveY(transform.position.y + 1, duration).SetEase(curve).SetLoops(-1);
        }

    }

}