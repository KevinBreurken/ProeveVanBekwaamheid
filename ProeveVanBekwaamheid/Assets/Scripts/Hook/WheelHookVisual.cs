using UnityEngine;
using System.Collections;

namespace Base.Game.Hooks {

    public class WheelHookVisual: MonoBehaviour {

        /// <summary>
        /// Own Spriterenderer
        /// </summary>
        private SpriteRenderer HookVisual;

        /// <summary>
        /// The sprite of the closed red hook
        /// </summary>
        public Sprite redhookSprite;

        /// <summary>
        /// The sprite of the closed green hook
        /// </summary>
        public Sprite greenhookSprite;

        /// <summary>
        /// The sprite of the closed yellow hook
        /// </summary>
        public Sprite yellowhookSprite;

        /// <summary>
        /// The sprite of the open red hook
        /// </summary>
        public Sprite redhookOpenSprite;

        /// <summary>
        /// The sprite of the open green hook
        /// </summary>
        public Sprite greenhookOpenSprite;

        /// <summary>
        /// The sprite of the open yellow hook
        /// </summary>
        public Sprite yellowhookOpenSprite;

        /// <summary>
        /// Current closed hook sprite
        /// </summary>
        private Sprite closedHookSprite;

        /// <summary>
        /// Current open hook sprite
        /// </summary>
        private Sprite openHookSprite;

        public void Awake() {
            HookVisual = GetComponent<SpriteRenderer>();

        }

        /// <summary>
        /// Gets the target color and sets the variables ready
        /// </summary>
        /// <param name="_targetColor">The target color</param>
        public void GetColor(ColorEnum _targetColor) {

            switch (_targetColor) {
                case ColorEnum.RED:
                    closedHookSprite = redhookSprite;
                    openHookSprite = redhookOpenSprite;
                    
                break;
                case ColorEnum.GREEN:
                    closedHookSprite = greenhookSprite;
                    openHookSprite = greenhookOpenSprite;

                break;
                case ColorEnum.YELLOW:
                    closedHookSprite = yellowhookSprite;
                    openHookSprite = yellowhookOpenSprite;

                break;
            }
            SetColor();
        }

        /// <summary>
        /// Sets the predetermined color into the spriterenderer
        /// </summary>
        private void SetColor() {
            HookVisual.sprite = closedHookSprite;

        }

        /// <summary>
        /// Switches the hook into an open hook
        /// </summary>
        public void OpenHook() {
            HookVisual.sprite = openHookSprite;

        }

        /// <summary>
        /// Switches the hook into a closed hook
        /// </summary>
        public void CloseHook() {
            HookVisual.sprite = closedHookSprite;

        }
    }
}