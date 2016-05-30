using UnityEngine;
using System.Collections;
using DG.Tweening;

/// <summary>
/// Contains effect related classes.
/// </summary>
namespace Base.Effect {

    /// <summary>
    /// A simple bobbing movement effect on the Y axis to simulate water.
    /// </summary>
    public class BobbingEffect : MonoBehaviour {

        /// <summary>
        /// Duration of the DOTween animation.
        /// </summary>
        public float duration;

        /// <summary>
        /// AnimationCurve of the DOTween animation.
        /// </summary>
        public AnimationCurve curve;

        void Awake () {

            //A tween that begins and ends at the same position doesn't work, lower its position.
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            //Then apply the Tween.
            transform.DOMoveY(transform.position.y + 1, duration).SetEase(curve).SetLoops(-1);

        }

    }

}