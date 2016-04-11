using UnityEngine;
using System.Collections;
using QStates;

namespace Base.Game {

    public class InGameState : BaseGameState {

        public override void Enter () {
            base.Enter();
        }

        public override IEnumerator Exit () {
            return base.Exit();
        }

        public override void Update () {
            base.Update();
        }

    }

}