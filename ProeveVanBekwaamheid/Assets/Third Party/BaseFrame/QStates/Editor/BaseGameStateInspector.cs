using UnityEngine;
using System.Collections;
using UnityEditor;
using Base.CustomEditor;

namespace QStates.Editors {

    [UnityEditor.CustomEditor(typeof(BaseGameState), false)]
    public class BaseGameStateInspector : Editor {

        private BaseGameState myScript;

        public override void OnInspectorGUI () {

            myScript = (BaseGameState)target;

            EditorGUILayout.HelpBox("You need to create a new GameState script and add it to this GameObject. \n \n" + 
                "See the Template folder for a template to use. When you've added that state to this GameObject, remove this Component.", MessageType.Error);

        }

    }

}
