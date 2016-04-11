using UnityEngine;
using System.Collections;
using QInput;

public class TestScript : MonoBehaviour {

    public BaseQInputMethod inputMethod;
    public BaseQInputMethod newInputMethod;
    public BaseQInputMethod otherInputMethod;

    // Use this for initialization
    void Start () {
        inputMethod = QInputManager.Instance.GetCurrentInputMethod();
        QInputManager.Instance.onInputChanged += Instance_onInputChanged;
	}

    private void Instance_onInputChanged (BaseQInputMethod _changedMethod) {
        inputMethod = _changedMethod;
        
    }

    // Update is called once per frame
    void Update () {

	    if(inputMethod != null) {
            Debug.Log(inputMethod.GetMovementInput());
        }

        if (Input.GetKeyDown(KeyCode.I)) {
            QInputManager.Instance.SetInputMethod(newInputMethod);
        }


        if (Input.GetKeyDown(KeyCode.O)) {
            QInputManager.Instance.SetInputMethod(otherInputMethod);
        }

    }

}
