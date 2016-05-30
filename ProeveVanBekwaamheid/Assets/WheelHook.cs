using UnityEngine;
using System.Collections;

namespace Base.Game.Hooks {
    public class WheelHook: HookBehaviour {
        public LineRenderer Chain;
        private Transform ChainHolder;

        public ColorEnum currentColor;
        public WheelHookVisual wheelHookVisual;

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
        

        public override void SetType() {
            ownHookColor = currentColor;
            wheelHookVisual.GetColor(currentColor);
            base.SetType();
        }
    }
}