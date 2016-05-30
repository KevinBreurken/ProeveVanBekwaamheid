using UnityEngine;
using System.Collections;

namespace Base.Effect {

    /// <summary>
    /// Animates a Sprite object.
    /// </summary>
    public class SpriteAnimator : MonoBehaviour {

        /// <summary>
        /// How fast the animation plays (Frames Per Second)
        /// </summary>
        public float FPS;

        /// <summary>
        /// If the animation loops.
        /// </summary>
        public bool isLooping;
        
        /// <summary>
        /// The frames this animation has.
        /// </summary>
        public Sprite[] frames;

        /// <summary>
        /// If the animation starts immediately
        /// </summary>
        public bool playOnStartup = false;

        /// <summary>
        /// which renderer(s) will get the output sprite.
        /// </summary>
        [SerializeField]
        private SpriteRenderer[] outputRenderers;

        private float secondsToWait;

        private int currentFrame;
        private bool stopped = false;


        public void Awake () {

            currentFrame = 0;
            if (FPS > 0)
                secondsToWait = 1 / FPS;
            else
                secondsToWait = 0f;

            if (playOnStartup) {
                Play(true);
            }

        }

        /// <summary>
        /// Plays the sprite animation.
        /// </summary>
        /// <param name="reset"></param>
        public void Play (bool reset = false) {

            if (reset) {

                currentFrame = 0;

            }

            stopped = false;

            for (int i = 0; i < outputRenderers.Length; i++) {

                outputRenderers[i].enabled = true;

            }

            if (frames.Length > 1) {

                Animate();

            } else if (frames.Length > 0) {

                for (int i = 0; i < outputRenderers.Length; i++) {

                    outputRenderers[i].sprite = frames[0];

                }

            }

        }

        /// <summary>
        /// Animates the outputRenderers.
        /// </summary>
        public virtual void Animate () {

            CancelInvoke("Animate");

            if (currentFrame >= frames.Length) {

                if (!isLooping) {

                    stopped = true;

                } else {

                    currentFrame = 0;

                }

            }

            for (int i = 0; i < outputRenderers.Length; i++) {

                outputRenderers[i].sprite = frames[currentFrame];

            }


            if (!stopped) {

                currentFrame++;

            }

            if (!stopped && secondsToWait > 0) {

                Invoke("Animate", secondsToWait);

            }

        }

    }

}
