using UnityEngine;
using System.Collections;

public class SpriteAnimator : MonoBehaviour {

    public float FPS;
    public bool isLooping;
    public Sprite[] frames;
    public bool playOnStartup = false;

    [SerializeField]
    private SpriteRenderer[] outputRenderers;
    private float secondsToWait;

    private int currentFrame;
    private bool stopped = false;

    // Use this for initialization
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
