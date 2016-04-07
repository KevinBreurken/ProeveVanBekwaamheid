using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Base.CustomEditor;

namespace QStates.Editors {

    [UnityEditor.CustomEditor(typeof(UIStateSelector))]
    public class UIStateSelectorInspector : Editor {

        private UIStateSelector myScript;

        public override void OnInspectorGUI () {

            myScript = (UIStateSelector)target;

            Draw.TitleField("Game States");

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Start State");
            myScript.startState = (BaseGameState)EditorGUILayout.ObjectField(myScript.startState, typeof(BaseUIState), true);
            EditorGUILayout.EndHorizontal();
            if (GUILayout.Button("Add New")) {

                myScript.States.Add(null);

            }

            for (int i = 0; i < myScript.States.Count; i++) {

                myScript.States[i] = DrawItem(myScript.States[i]);

            }

        }

        private GameObject DrawItem (GameObject _data) {

            EditorGUILayout.BeginHorizontal("Box");

            //----Item Properties---------------------------------------------------------->
            EditorGUILayout.BeginVertical();
            _data = Draw.DrawGameObjectField(_data, "UI State Object", true);
            if (_data != null) {

                string newstring = _data.GetComponent<QState>().GetType().ToString().Remove(0, 8);
                EditorGUILayout.LabelField("Identifier: " + newstring);

            }
            EditorGUILayout.EndVertical();
            //----------------------------------------------------------------------------->

            //----Remove / Up / Down Buttons-------------------------------------------------->
            EditorGUILayout.BeginVertical();
            if (GUILayout.Button("X", GUILayout.Width(100))) {

                myScript.States.Remove(_data);

            }

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("^", GUILayout.Width(50))) {
                int index = myScript.States.IndexOf(_data);
                if (index != 0) {
                    SwapItems(myScript.States, index, index - 1);
                }
            }

            if (GUILayout.Button("V", GUILayout.Width(50))) {
                int index = myScript.States.IndexOf(_data);
                if (index != myScript.States.Count - 1) {
                    SwapItems(myScript.States, index, index + 1);
                }
            }

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
            //------------------------------------------------------------------------------>

            EditorGUILayout.EndHorizontal();

            return _data;

        }

        public static void SwapItems (List<GameObject> list, int indexA, int indexB) {

            GameObject tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;

        }

    }


}