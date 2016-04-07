using UnityEngine;
using System.Collections;
using UnityEditor;

namespace Base.CustomEditor {

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