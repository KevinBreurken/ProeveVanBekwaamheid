using UnityEngine;
using System.Collections;

namespace Base.Game.Hooks {

    public class WheelHookVisual: MonoBehaviour {

        private SpriteRenderer HookVisual;

        public Sprite redhookSprite;
        public Sprite greenhookSprite;
        public Sprite yellowhookSprite;

        public Sprite redhookOpenSprite;
        public Sprite greenhookOpenSprite;
        public Sprite yellowhookOpenSprite;

        private Sprite closedHookSprite;
        private Sprite openHookSprite;

        public void Awake() {
            HookVisual = GetComponent<SpriteRenderer>();

        }

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
        }

        private void SetColor() {
            HookVisual.sprite = yellowhookSprite;
        }
    }
}