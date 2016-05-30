 using UnityEngine;
using System.Collections;

namespace Base.Effect {
	
	/// <summary>
	/// Used for the water background.
	/// </summary>
	public class TargetFollower : MonoBehaviour {

        /// <summary>
        /// The target this camera follows
        /// </summary>
        public GameObject target;
        /// <summary>
        /// How fast it moves
        /// </summary>
        public float factor = 1;
        /// <summary>
        /// If it uses it's original postion.
        /// </summary>
        public bool useOriginalPosition = false;
        /// <summary>
        /// It's original position
        /// </summary>
        public Vector3 originalPosition;

        void Awake (){

			if(useOriginalPosition)
				originalPosition = transform.position;
			
		}

		// Update is called once per frame
		void Update () {
		
			if(useOriginalPosition){
				
				transform.position = new Vector3(originalPosition.x - (target.transform.position.x * factor),transform.position.y,transform.position.z);

			} else {
				
				transform.position = new Vector3(target.transform.position.x,transform.position.y,transform.position.z);


			}

		}

	}

}
