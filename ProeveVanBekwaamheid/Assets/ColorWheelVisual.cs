using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace Base.Game.Hooks {
    public class ColorWheelVisual: MonoBehaviour {

        public bool turning = false;
        private float Zpos;
        public float turnSpeed;

        void Start() {
            if (turnSpeed == 0) 
                turnSpeed = 1;
        }

        private void Update() {

            if (turning == true)
                TurnWheel();
        }

        public void TurnWheel() {
            
            Zpos -= turnSpeed;
            transform.localEulerAngles = new Vector3(0,0,Zpos);
        }

        public void SetWheelToColor(ColorEnum _targetColor) {
            float randomValue;
            switch (_targetColor) {
                case ColorEnum.GREEN:
                    randomValue = Random.Range(180,230);
                    StartCoroutine("RotationDelay",randomValue);
                    turning = false;
                break;
                case ColorEnum.YELLOW:
                    randomValue = Random.Range(60,120);
                    StartCoroutine("RotationDelay",randomValue);
                    turning = false;
                break;
                case ColorEnum.RED:
                    randomValue = Random.Range(120,180);
                    StartCoroutine("RotationDelay",randomValue);
                    turning = false;
                break;
            }
        }

        private IEnumerator RotationDelay(float targetZPos) {
            
            yield return new WaitForEndOfFrame();
            transform.DORotate(new Vector3(0,0,targetZPos),0.9f,RotateMode.FastBeyond360);

        }
    }
}