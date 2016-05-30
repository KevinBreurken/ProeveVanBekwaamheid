using UnityEngine;
using System.Collections;
using UnityEditor;
using BaseFrame.QUI;
using BaseFrame.CustomEditor;
using BaseFrame.QUI.Editors;

namespace BaseFrame.QUI.Editors {

    /// <summary>
    /// Custom inspector for the QUIButton component.
    /// </summary>
    [UnityEditor.CustomEditor(typeof(QUIButton),false)]
    public class QUIButtonInspector : Editor {

        private QUIButton myScript;
        
		/// <summary>
		/// Draws the custom inspector.
		/// </summary>
        public override void OnInspectorGUI () {

            myScript = (QUIButton)target;

            Draw.TitleField("UI Button");
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