using UnityEngine;
using System.Collections;
using Base.Game.Hooks;

namespace Base.Game.Fish {

    /// <summary>
    /// Behaviour of the EelFish.
    /// </summary>
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
            _target.hookInteracted = true;
            _target.ShockHook();
            return true;

        }


    }
}