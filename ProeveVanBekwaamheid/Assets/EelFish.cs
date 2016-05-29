using UnityEngine;
using System.Collections;
using Base.Game.Hooks;

namespace Base.Game.Fish {

    public class EelFish:  FishBehaviour{
        public void Start() {

            speed = Random.Range(20,30);
            Init();

        }

        public void OnEnable() {

            speed = Random.Range(20,30);
            InMotion = true;

        }

        void Update() {

            SwimDirection(ownDirection);
            OutOfBound();

        }

        public override void SetType() {
            requiredHookColor = ColorEnum.NONE;
        }
        public override bool RespondToHook(HookBehaviour _target) {
            base.RespondToHook(_target);
            return true;

        }


    }
}