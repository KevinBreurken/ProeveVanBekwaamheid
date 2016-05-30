using UnityEngine;
using System.Collections;
using System;

namespace Base.Game.Hooks {
    public class WheelHook: HookBehaviour {
        public LineRenderer Chain;
        private Transform ChainHolder;

        public ColorEnum currentColor;
        public WheelHookVisual wheelHookVisual;
        public ColorWheelVisual colorWheelVisual;

        void Start() {
            ChainHolder = Chain.transform;
            wheelHookVisual = GetComponentInChildren<WheelHookVisual>();
            Init();
        }

        void Update() {
            Chain.SetPosition(0,new Vector3(ChainHolder.position.x,ChainHolder.position.y,-0.1f));
            Chain.SetPosition(1,new Vector3(transform.position.x,transform.position.y + 0.2f,-0.1f));
            hookUpdate();
        }

        public override bool PullHook() {
            colorWheelVisual.turning = true;
            return base.PullHook();
        }

        public override void OnHookReturned() {
            base.OnHookReturned();
            colorWheelVisual.turning = false;
            SetNextColor();
            SetType();
        }

        public override void SetType() {
            ownHookColor = currentColor;
            wheelHookVisual.GetColor(currentColor);
            colorWheelVisual.SetWheelToColor(currentColor);
            base.SetType();
        }

        public void SetNextColor() {
            int AmountOfColors = Enum.GetValues(typeof(ColorEnum)).Length - 1;
            for (int i = 0;i < AmountOfColors;i++) {
                if ((ColorEnum)Enum.ToObject(typeof(ColorEnum),i) == currentColor) {
                    Debug.Log("int i" + (i + 1) + " Amount of Colors = " + AmountOfColors);
                    if (i + 1 >= AmountOfColors) {
                        currentColor = (ColorEnum)Enum.ToObject(typeof(ColorEnum),0);
                        Debug.Log((ColorEnum)Enum.ToObject(typeof(ColorEnum),0));
                        break;

                    }
                    else {
                        currentColor = (ColorEnum)Enum.ToObject(typeof(ColorEnum),i + 1);
                        Debug.Log((ColorEnum)Enum.ToObject(typeof(ColorEnum),i + 1));
                        break;

                    }
                }
            }
        }
    }
}