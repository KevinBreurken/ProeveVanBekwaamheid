using UnityEngine;
using System.Collections;

namespace Base.Game.Fish {

    public class HousingBase: MonoBehaviour {

        /// <summary>
        /// Check if the House is occupied
        /// </summary>
        public bool occupied;

        /// <summary>
        /// Checks with the colliders if hits with an object you can interact with
        /// </summary>
        /// <param name="_other"></param>
        void OnTriggerEnter2D(Collider2D _other) {

            if (_other.gameObject.tag == "Fish")
                InteractWithFish();

        }

        /// <summary>
        /// The interaction with the fish
        /// </summary>
        public virtual void InteractWithFish() {

        }

        /// <summary>
        /// Target claims ownership of this housing
        /// </summary>
        /// <param name="_target"></param>
        public void ClaimOwnership(FishInstinct _target) {

            occupied = true;

        }

        /// <summary>
        /// Target loses ownership of this target
        /// </summary>
        public void LoseOwnership() {

            occupied = false;

        }

    }

}

