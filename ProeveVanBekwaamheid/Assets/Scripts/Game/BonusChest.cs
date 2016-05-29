using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using Base.Manager;

namespace Base.Game {

    /// <summary>
    /// A chest thats used in the BonusEvent.
    /// </summary>
    public class BonusChest : MonoBehaviour {

        public delegate void ChestEvent (BonusChest _chest);

        /// <summary>
        /// Called when the chest is opened.
        /// </summary>
        public event ChestEvent OnChestOpened;

        /// <summary>
        /// Called when the opening animation is finished.
        /// </summary>
        public event ChestEvent OnChestOpenAnimationEnded;

        /// <summary>
        /// Reference to the chest graphic.
        /// </summary>
        public SpriteRenderer chestGraphic;

        /// <summary>
        /// Reference to the glow graphic.
        /// </summary>
        public SpriteRenderer glowGraphic;

        /// <summary>
        /// Reference to the ray graphic.
        /// </summary>
        public SpriteRenderer rayGraphic;

        /// <summary>
        /// If the chest is interactable.
        /// </summary>
        private bool isInteractable;

        /// <summary>
        /// The closed chest sprite.
        /// </summary>
        private Sprite closedSprite;

        /// <summary>
        /// Reference to the chest graphic transform.
        /// </summary>
        private Transform graphicTransform;

        /// <summary>
        /// Starting position of the chest graphic.
        /// </summary>
        private Vector3 graphicStartPosition;

        /// <summary>
        /// Starting rotation of the chest graphic.
        /// </summary>
        private Quaternion graphicStartLocalRotation;

        /// <summary>
        /// The low buzzing tone that's played when hovered over the chest.
        /// </summary>
        public AudioSource lowToneSource;

        /// <summary>
        /// The opening sound.
        /// </summary>
        public AudioSource openingSource;

        /// <summary>
        /// The open chest sprite.
        /// </summary>
        public Sprite openSprite;

        public Text textPopup;

        public int score;

        void Awake () {

            graphicTransform = chestGraphic.GetComponent<Transform>();
            closedSprite = chestGraphic.sprite;

            chestGraphic.color = new Color(1, 1, 1, 0);
            glowGraphic.color = new Color(1, 1, 1, 0);
            rayGraphic.color = new Color(1, 1, 1, 0);

            graphicStartPosition = chestGraphic.transform.localPosition;
            graphicStartLocalRotation = graphicTransform.transform.localRotation;
            lowToneSource = GetComponent<AudioSource>();

        }

        /// <summary>
        /// Activates the chest.
        /// </summary>
        public void Activate () {

            isInteractable = true;
            chestGraphic.sprite = closedSprite;
            chestGraphic.color = new Color(1, 1, 1, 0);
            graphicTransform.eulerAngles = new Vector3(0, 0, 0);
            graphicTransform.localScale = new Vector3(1, 1, 1);
            graphicTransform.localPosition = graphicStartPosition;
            lowToneSource.pitch = 1;
            textPopup.color = new Color(1, 1, 1, 0);

            chestGraphic.DOFade(1, 1);

        }

        /// <summary>
        /// Sets the score that this chest gives to the player.
        /// </summary>
        /// <param name="_score">The score value.</param>
        public void SetScore (int _score) {

            score = _score;

        }

        /// <summary>
        /// Deactivates the chest.
        /// </summary>
        /// <param name="_delay">how long it takes before the graphic fades out.</param>
        public void Deactivate (int _delay) {

            isInteractable = false;

            chestGraphic.DOFade(0, 1).SetDelay(_delay);
            glowGraphic.DOFade(0, 1).SetDelay(_delay);
            rayGraphic.DOFade(0, 1).SetDelay(_delay);
            StopAllCoroutines();
            lowToneSource.DOFade(0, 1);
            textPopup.DOKill();
            textPopup.DOFade(0, 0.1f);
            DOTween.Kill(2010 + this.GetInstanceID());

        }

        /// <summary>
        /// Plays the opening animation.
        /// </summary>
        /// <returns></returns>
        private IEnumerator PlayOpeningAnimation () {

            DOTween.Kill(2009 + this.GetInstanceID());
            lowToneSource.DOPitch(12f, 0.7f);
            rayGraphic.transform.eulerAngles = new Vector3(0, 0, 0);
            rayGraphic.transform.DOLocalRotate(new Vector3(0, 0, 3000), 10,RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
            graphicTransform.DOShakeRotation(2f, new Vector3(0, 0, 25), 40).SetId(2010 + this.GetInstanceID()).SetLoops(-1);
            lowToneSource.DOFade(0.3f, 0.3f);
            textPopup.transform.localScale = new Vector3(0, 0, 0);
            textPopup.text = "+" + score;

            yield return new WaitForSeconds(0.5f);
            graphicTransform.DOScale(1.2f, 0.3f).SetEase(Ease.InOutBack);
            glowGraphic.DOFade(1, 0.5f);
            rayGraphic.DOFade(1, 0.3f).SetDelay(0.2f);

            yield return new WaitForSeconds(0.2f);
            DOTween.Kill(2010 + this.GetInstanceID());
            graphicTransform.eulerAngles = new Vector3(0, 0, 0);
            chestGraphic.sprite = openSprite;
            openingSource.Play();

            textPopup.DOFade(1, 0.5f);
            textPopup.transform.DOLocalMoveY(2, 1);
            textPopup.transform.DOScale(1.0f, 1).SetEase(Ease.OutBack);
            
            yield return new WaitForSeconds(0.2f);
            lowToneSource.DOFade(0, 0.3f);
            graphicTransform.DOLocalMove(graphicStartPosition, 0.5f).SetEase(Ease.OutBack);
            graphicTransform.DOScale(1, 0.2f).SetEase(Ease.Linear);
            ScoreManager.Instance.AddScore(score);
            yield return new WaitForSeconds(1.5f);
            textPopup.DOFade(0, 0.5f);

            yield return new WaitForSeconds(1.5f);
            if (OnChestOpenAnimationEnded != null)
                OnChestOpenAnimationEnded(this);

        }

        /// <summary>
        /// Called when the player presses on the chest.
        /// </summary>
        public void OnMouseDown () {

            if (!isInteractable)
                return;
            if (OnChestOpened != null)
                OnChestOpened(this);

            isInteractable = false;
            StartCoroutine("PlayOpeningAnimation");

        }

        /// <summary>
        /// Called when the mouse pointer enters the graphic.
        /// </summary>
        public void OnMouseEnter () {
            if (!isInteractable)
                return;

            lowToneSource.Play();
            lowToneSource.DOFade(1, 0.3f);
            graphicTransform.DOLocalMove(graphicStartPosition + new Vector3(0,1,0), 1);

            if (DOTween.TweensById(2009 + this.GetInstanceID()) == null)
                graphicTransform.DOShakeRotation(1f, new Vector3(0, 0, 15), 40).SetId(2009 + this.GetInstanceID()).SetLoops(-1);

        }

        /// <summary>
        /// Called when the mouse pointer exits the graphic.
        /// </summary>
        public void OnMouseExit () {
            if (!isInteractable)
                return;

            graphicTransform.DOLocalMove(graphicStartPosition, 1);
            DOTween.Kill(2009 + this.GetInstanceID());
            graphicTransform.eulerAngles = new Vector3(0, 0, 0);
            lowToneSource.DOFade(0, 1);

        }

    }

}