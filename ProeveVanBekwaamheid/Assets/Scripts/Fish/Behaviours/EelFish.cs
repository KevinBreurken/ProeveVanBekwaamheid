using UnityEngine;
using System.Collections;
using Base.Game.Hooks;

namespace Base.Game.Fish {

    /// <summary>
    /// Behaviour of the EelFish.
    /// </summary>
    public class EelFish:  FishBehaviour{
        public void Start() {

            currentSpeed = speed + Random.Range(-speedRandom,speedRandom);
            Init();

        }

        public void OnEnable() {

            currentSpeed = speed + Random.Range(-speedRandom,speedRandom);
            InMotion = true;

        }

        void FixedUpdate() {

            SwimDirection(ownDirection);
            OutOfBound();

        }


        public override void SetType() {
            requiredHookColor = ColorEnum.NONE;
        }

        public override bool RespondToHook(HookBehaviour _target) {

            currentSpeed += 20;
            _target.hookInteracted = true;
            _target.ShockHook();
            return true;

        }


    }
}