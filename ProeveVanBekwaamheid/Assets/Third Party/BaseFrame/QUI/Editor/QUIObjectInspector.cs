using UnityEngine;
using System.Collections;
using UnityEditor;
using QUI;
using QUI.Editors;
using Base.CustomEditor;

namespace QUI.Editors {

    [UnityEditor.CustomEditor(typeof(QUIObject))]
    public class QUIObjectInspector : Editor {

        private QUIObject myScript;

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