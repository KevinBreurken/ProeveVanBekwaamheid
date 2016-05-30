using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// Contains classes related to custom editors.
/// </summary>
namespace BaseFrame.CustomEditor {

    /// <summary>
    /// A utility class used within the editor for multiple purposes.
    /// </summary>
    public class EditorCustomUtility {

        /// <summary>
        /// Creates a new GameObject in the hierarchy and selects that GameObject.
        /// </summary>
        public static GameObject CreateGameObjectInEditor (string _name) {

            GameObject go = new GameObject(_name);
            GameObject currentSelection = Selection.activeGameObject;

            if(currentSelection != null)
            go.transform.SetParent(currentSelection.transform);

            go.transform.position = new Vector3(0, 0, 0);

            Selection.activeGameObject = go;

            return go;

        }

    }

}