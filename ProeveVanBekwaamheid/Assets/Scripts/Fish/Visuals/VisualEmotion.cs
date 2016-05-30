using UnityEngine;
using System.Collections;

namespace Base.Game.Fish {
	
    /// <summary>
    /// Displays what kind of emotion the fish has.
    /// </summary>
	public class VisualEmotion : MonoBehaviour {

        /// <summary>
        /// Spriterenderer that will hold the bubbles
        /// </summary>
	    private SpriteRenderer ownSpriteRenderer;

        /// <summary>
        /// The Sprite that shows a Question emotion
        /// </summary>
	    public Sprite QuestionSprite;

        /// <summary>
        /// The sprite that shows a Shocking emotion
        /// </summary>
	    public Sprite ShockSprite;

	    void Start() {
			
	        ownSpriteRenderer = GetComponent<SpriteRenderer>();

	    }

        /// <summary>
        /// The function that calls the emotion for the fish
        /// </summary>
        /// <param name="_targetEmotion">Emotion that will pop up for the fish</param>
	    public void Emote(Emotions _targetEmotion) {
			
	        switch (_targetEmotion) {

	            case Emotions.QUESTION:
	                ownSpriteRenderer.sprite = QuestionSprite;
	                StartCoroutine("TurnSpriteOff");
	            break;

	            case Emotions.SHOCK:
	                ownSpriteRenderer.sprite = ShockSprite;
	                StartCoroutine("TurnSpriteOff");
	            break;

	        }

	    }

        /// <summary>
        /// hiding the sprite that shows the emotions
        /// </summary>
        /// <returns></returns>
	    IEnumerator TurnSpriteOff() {
			
	        yield return new WaitForSeconds(0.5f);
	        ownSpriteRenderer.sprite = null;

	    }

	}

    /// <summary>
    /// The emotions a fish can show using bubbles
    /// </summary>
	public enum Emotions {
		
        /// <summary>
        /// If the object is in a questioning state.
        /// </summary>
	    QUESTION,
        /// <summary>
        /// If the object is in a shock state.
        /// </summary>
	    SHOCK


	}

}