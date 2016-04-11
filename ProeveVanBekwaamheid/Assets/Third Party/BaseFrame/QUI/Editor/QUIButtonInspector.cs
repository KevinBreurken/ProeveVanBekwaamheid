using UnityEngine;
using System.Collections;
using UnityEditor;
using QUI;
using Base.CustomEditor;
using QUI.Editors;

namespace QUI.Editors {

    [UnityEditor.CustomEditor(typeof(QUIButton),false)]
    public class QUIButtonInspector : Editor {

        private QUIButton myScript;
        
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