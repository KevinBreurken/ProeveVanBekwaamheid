using UnityEngine;
using System.Collections;
using UnityEditor;
using QUI;
using Base.CustomEditor;

namespace QUI.Editors {

    public class QUIEditorMenuItems {

        [MenuItem("BaseFrame/QUI/QUIObject")]
        static void CreateQUIObject () {

            GameObject go = EditorCustomUtility.CreateGameObjectInEditor("QUIObject");
            go.AddComponent<QUIObject>();

        }

        [MenuItem("BaseFrame/QUI/QUIButton")]
        static void CreateQUIButton () {

            if (Selection.activeGameObject != null) {

                if (Selection.activeGameObject.GetComponent<RectTransform>() == null) {

                    Debug.LogError("Selected GameObject is not a UI Element. (It has no RectTransform Component)");

                } else {

                    GameObject go = EditorCustomUtility.CreateGameObjectInEditor("QUIButton");
                    go.AddComponent<QUIButton>();

                }

            } else {

                Debug.LogError("No GameObject selected. select a GameObject that is part of your UI hierarchy.");

            }

        }

    }

}
