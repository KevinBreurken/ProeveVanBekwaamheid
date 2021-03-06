﻿using UnityEngine;
using System.Collections;
using UnityEditor;
using BaseFrame.CustomEditor;

namespace BaseFrame.QStates.Editors {

    /// <summary>
    /// Custom inspector for the BaseGameState component.
    /// </summary>
    [UnityEditor.CustomEditor(typeof(BaseGameState), false)]
    public class BaseGameStateInspector : Editor {

		/// <summary>
		/// Draws the custom inspector.
		/// </summary>
        public override void OnInspectorGUI () {

            EditorGUILayout.HelpBox("You need to create a new GameState script and add it to this GameObject. \n \n" + 
                "See the Template folder for a template to use. When you've added that state to this GameObject, remove this Component.", MessageType.Error);

        }

    }

}
