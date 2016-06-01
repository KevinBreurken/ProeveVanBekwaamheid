using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace Base.Game.Hooks {

    /// <summary>
    /// Controls the color wheel that's located on the boat.
    /// </summary>
    public class ColorWheelVisual: MonoBehaviour {

        /// <summary>
        /// Checks if the wheel is turning
        /// </summary>
        public bool turning = false;

        /// <summary>
        /// The float that keeps track of the targets Z rotation
        /// </summary>
        private float Zpos;

        /// <summary>
        /// The speed the wheel turns with
        /// </summary>
        public float turnSpeed;


        void Start() {
            if (turnSpeed == 0) 
                turnSpeed = 1;
        }

        private void Update() {

            if (turning == true)
                TurnWheel();
        }

        /// <summary>
        /// The function that lets the wheel turn
        /// </summary>
        public void TurnWheel() {
            
            Zpos -= turnSpeed;
            transform.localEulerAngles = new Vector3(0,0,Zpos);
        }

        /// <summary>
        /// Sets the wheel to its target color
        /// </summary>
        /// <param name="_targetColor">The target color</param>
        public void SetWheelToColor(ColorEnum _targetColor) {
            float randomValue;
            switch (_targetColor) {
                case ColorEnum.GREEN:
                    randomValue = Random.Range(180,230);
                    StartCoroutine("RotationDelay",randomValue);
                  break;
                case ColorEnum.YELLOW:
                    randomValue = Random.Range(60,120);
                    StartCoroutine("RotationDelay",randomValue);
                 break;
                case ColorEnum.RED:
                    randomValue = Random.Range(120,180);
                    StartCoroutine("RotationDelay",randomValue);
                break;
            }
        }

        /// <summary>
        /// A minor delay for the wheel to turn
        /// </summary>
        /// <param name="targetZPos">Target Z position the wheel needs to end</param>
        /// <returns></returns>
        private IEnumerator RotationDelay(float targetZPos) {
            
            yield return new WaitForEndOfFrame();
            transform.DORotate(new Vector3(0,0,targetZPos),0.9f,RotateMode.FastBeyond360);

        }
    }
}