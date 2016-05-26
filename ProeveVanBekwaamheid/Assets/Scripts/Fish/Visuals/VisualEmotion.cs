using UnityEngine;
using System.Collections;

namespace Base.Game.Fish.Emotion {
	
	public class VisualEmotion : MonoBehaviour {

	    private SpriteRenderer ownSpriteRenderer;
	    public Sprite QuestionSprite;
	    public Sprite ShockSprite;

	    void Start() {
			
	        ownSpriteRenderer = GetComponent<SpriteRenderer>();

	    }

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

	    IEnumerator TurnSpriteOff() {
			
	        yield return new WaitForSeconds(0.5f);
	        ownSpriteRenderer.sprite = null;

	    }

	}

	public enum Emotions {
		
	    QUESTION,
	    SHOCK


	}

}