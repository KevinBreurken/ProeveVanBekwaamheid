using UnityEngine;
using System.Collections;
using UnityEditor;
using BaseFrame.QUI;
using BaseFrame.CustomEditor;
using UnityEngine.UI;

/// <summary>
/// Custom Editors for QUI related components.
/// </summary>
namespace BaseFrame.QUI.Editors {

	/// <summary>
	/// Custom menu items for QUI.
	/// </summary>
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

        [MenuItem("BaseFrame/QUI/QUIToggle")]
        static void CreateQUIToggle () {

            if (Selection.activeGameObject != null) {

                if (Selection.activeGameObject.GetComponent<RectTransform>() == null) {

                    Debug.LogError("Selected GameObject is not a UI Element. (It has no RectTransform Component)");

                } else {

                    GameObject go = EditorCustomUtility.CreateGameObjectInEditor("QUIToggle");
                    go.AddComponent<QUIToggle>();

                    GameObject checkmark = new GameObject("Checkmark");
                    checkmark.AddComponent<Image>();
                    checkmark.transform.parent = go.transform;
                    checkmark.GetComponent<Image>().color = Color.green;

                    go.GetComponent<Toggle>().graphic = checkmark.GetComponent<Image>();

                }

            } else {

                Debug.LogError("No GameObject selected. select a GameObject that is part of your UI hierarchy.");

            }

        }

    }

}
