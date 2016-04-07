using UnityEngine;
using System.Collections;
using UnityEditor;
using Base.CustomEditor;

namespace QStates.Editors {

    [UnityEditor.CustomEditor(typeof(BaseUIState), false)]
    public class BaseUIStateInspector : Editor {

        private BaseUIState myScript;

        public override void OnInspectorGUI () {

            myScript = (BaseUIState)target;

            EditorGUILayout.HelpBox("You need to create a new UIState script and add it to this GameObject. \n \n" +
                "See the Template folder for a template to use. When you've added that state to this GameObject, remove this Component.", MessageType.Error);

        }

    }

}
