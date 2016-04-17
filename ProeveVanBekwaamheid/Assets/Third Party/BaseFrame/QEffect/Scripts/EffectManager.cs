using UnityEngine;
using System.Collections;
using BaseFrame.QEffect.Effects;

/// <summary>
/// QEffect: Part of BaseFrame that handles Effects.
/// </summary>
namespace BaseFrame.QEffect {

    /// <summary>
    /// A singleton that handles all effects.
    /// </summary>
    public class EffectManager : MonoBehaviour {

        private static EffectManager instance = null;
        /// <summary>
        /// Static reference of the EffectManager.
        /// </summary>
        public static EffectManager Instance {

            get {

                if (instance == null) {

                    instance = FindObjectOfType(typeof(EffectManager)) as EffectManager;

                }

                return instance;

            }

        }

        /// <summary>
        /// Reference to the FadeEffect class.
        /// </summary>
        public FadeEffect FadeEffect;

        /// <summary>
        /// Reference to the ContrastSetter class.
        /// </summary>
        public ContrastSetter Contrast;

    }

}
