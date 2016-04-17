using UnityEngine;
using System.Collections;
using UnityEditor;
using BaseFrame.QUI;
using BaseFrame.QUI.Editors;
using BaseFrame.CustomEditor;

namespace BaseFrame.QUI.Editors {

    /// <summary>
    /// Custom inspector for the QUIObject component.
    /// </summary>
    [UnityEditor.CustomEditor(typeof(QUIObject))]
    public class QUIObjectInspector : Editor {

        private QUIObject myScript;

		/// <summary>
		/// Draws the custom inspector.
		/// </summary>
        public override void OnInspectorGUI () {

            myScript = (QUIObject)target;

            Draw.TitleField("UI Object");
            myScript.showAnimationData = QUIDraw.DrawAnimationDataPanel(myScript.showAnimationData, "Show Animation");
            EditorGUILayout.Space();
            myScript.hideAnimationData = QUIDraw.DrawAnimationDataPanel(myScript.hideAnimationData, "Hide Animation");

            EditorGUILayout.Space();
            myScript.pointerEnterAnimationData = QUIDraw.DrawAnimationDataPanel(myScript.pointerEnterAnimationData, "Pointer Enter Animation");

            EditorGUILayout.Space();
            myScript.pointerExitAnimationData = QUIDraw.DrawAnimationDataPanel(myScript.pointerExitAnimationData, "Pointer Exit Animation");

        }

       

    }

}