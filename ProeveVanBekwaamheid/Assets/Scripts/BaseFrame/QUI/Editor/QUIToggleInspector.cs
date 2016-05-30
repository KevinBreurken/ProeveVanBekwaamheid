using UnityEngine;
using System.Collections;
using UnityEditor;
using BaseFrame.QUI;
using BaseFrame.QUI.Editors;
using BaseFrame.CustomEditor;

namespace BaseFrame.QUI.Editors {

    /// <summary>
    /// Custom inspector for the QUIToggle component.
    /// </summary>
    [UnityEditor.CustomEditor(typeof(QUIToggle))]
    public class QUIToggleInspector : Editor {

        private QUIToggle myScript;

		/// <summary>
		/// Draws the custom inspector.
		/// </summary>
        public override void OnInspectorGUI () {

            myScript = (QUIToggle)target;

            Draw.TitleField("UI Toggle");
            myScript.normalSprite = Draw.DrawSpriteField(myScript.normalSprite, "Normal Sprite", false);

            myScript.pointerClickAnimationData = QUIDraw.DrawAnimationDataPanel(myScript.pointerClickAnimationData, "Click Animation");
            EditorGUILayout.Space();
            myScript.showAnimationData = QUIDraw.DrawAnimationDataPanel(myScript.showAnimationData, "Show Animation");
            EditorGUILayout.Space();
            myScript.hideAnimationData = QUIDraw.DrawAnimationDataPanel(myScript.hideAnimationData, "Hide Animation");
            EditorGUILayout.Space();
            myScript.pointerEnterAnimationData = QUIDraw.DrawAnimationDataPanel(myScript.pointerEnterAnimationData, "Enter Animation");
            EditorGUILayout.Space();
            myScript.pointerExitAnimationData = QUIDraw.DrawAnimationDataPanel(myScript.pointerExitAnimationData, "Exit Animation");

        }



    }

}