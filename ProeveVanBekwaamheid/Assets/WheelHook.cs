﻿using UnityEngine;
using System.Collections;
using System;

namespace Base.Game.Hooks {
    public class WheelHook: HookBehaviour {
        /// <summary>
        /// The chain that follows the target hook
        /// </summary>
        public LineRenderer Chain;
        private Transform ChainHolder;

        /// <summary>
        /// The color the current hook holds
        /// </summary>
        public ColorEnum currentColor;

        /// <summary>
        /// The visual of the hook
        /// </summary>
        public WheelHookVisual wheelHookVisual;

        /// <summary>
        /// The visual of the color wheel
        /// </summary>
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

        public override bool LooseHook() {

            wheelHookVisual.OpenHook();
            return base.LooseHook();
        }
        public override bool PullHook() {
            colorWheelVisual.turning = true;
            wheelHookVisual.CloseHook();
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

        /// <summary>
        /// Sets the current Color into the next color in line
        /// </summary>
        public void SetNextColor() {
            int AmountOfColors = Enum.GetValues(typeof(ColorEnum)).Length - 1;
            for (int i = 0;i < AmountOfColors;i++) {
                if ((ColorEnum)Enum.ToObject(typeof(ColorEnum),i) == currentColor) {
                    if (i + 1 >= AmountOfColors) {
                        currentColor = (ColorEnum)Enum.ToObject(typeof(ColorEnum),0);
                        break;

                    }
                    else {
                        currentColor = (ColorEnum)Enum.ToObject(typeof(ColorEnum),i + 1);
                        break;

                    }
                }
            }
        }
    }
}