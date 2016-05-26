using UnityEngine;
using System.Collections;


namespace Base.Game.Hooks {
    /// <summary>
    /// Behaviour for the Green hook
    /// </summary>
    public class GreenHook: HookBehaviour {
        public LineRenderer Chain;
        private Transform ChainHolder;

        void Start() {
            ChainHolder = Chain.transform;
            Init();
        }

        void Update() {
            Chain.SetPosition(0,new Vector3(ChainHolder.position.x,ChainHolder.position.y,-0.1f));
            Chain.SetPosition(1,new Vector3(transform.position.x,transform.position.y + 0.2f,-0.1f));
            hookUpdate();
        }

        public override void SetType() {
            ownHookColor = HookColors.GREEN;
            base.SetType();
        }
    }
}