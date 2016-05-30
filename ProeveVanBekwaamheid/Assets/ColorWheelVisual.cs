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

            Zpos += turnSpeed;
            transform.localEulerAngles = new Vector3(0,0,Zpos);
        }

        public void SetWheelToColor(ColorEnum _targetColor) {
            float randomValue;
            switch (_targetColor) {
                case ColorEnum.GREEN:
                    randomValue = Random.Range(180,230);
                    transform.DOLocalRotate(new Vector3(0,0,randomValue),0.5f,RotateMode.Fast);
                    turning = false;
                break;
                case ColorEnum.YELLOW:
                    randomValue = Random.Range(60,120);
                    transform.DOLocalRotate(new Vector3(0,0,randomValue),0.5f,RotateMode.Fast);
                    turning = false;
                break;
                case ColorEnum.RED:
                    randomValue = Random.Range(120,180);
                    transform.DOLocalRotate(new Vector3(0,0,randomValue),0.5f,RotateMode.Fast);
                    turning = false;
                break;
            }
        }
    }
}