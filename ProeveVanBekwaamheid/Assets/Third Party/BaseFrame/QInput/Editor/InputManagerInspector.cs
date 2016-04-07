using UnityEngine;
using UnityEditor;
using System.Collections;
using QInput;
using System.Collections.Generic;
using Base.CustomEditor;

namespace QInput.Editors {

    [CustomEditor(typeof(QInputManager))]
    public class InputManagerInspector : Editor {

        private QInputManager myScript;

        public override void OnInspectorGUI () {

            myScript = (QInputManager)target;

            Draw.TitleField("Input Manager");

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Start Input Method");
            myScript.startInputMethod = (BaseQInputMethod)EditorGUILayout.ObjectField(myScript.startInputMethod, typeof(BaseQInputMethod), true);
            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Add New")) {

                myScript.inputMethods.Add(null);

            }

            for (int i = 0; i < myScript.inputMethods.Count; i++) {

                myScript.inputMethods[i] = DrawItem(myScript.inputMethods[i]);

            }

        }

        private BaseQInputMethod DrawItem (BaseQInputMethod _data) {

            EditorGUILayout.BeginHorizontal("Box");

            //----Item Properties---------------------------------------------------------->
            EditorGUILayout.BeginVertical();

            if(_data == null) {

                GameObject obj = null;
                obj = Draw.DrawGameObjectField(obj, "UI State Object", true);

                if(obj != null) {

                    if (obj.GetComponent<BaseQInputMethod>()) {

                        _data = obj.GetComponent<BaseQInputMethod>();
                        return _data;

                    }

                }

            }

            if (_data != null) {
              
                string newstring = _data.GetComponent<BaseQInputMethod>().GetType().ToString().Remove(0, 7);
                EditorGUILayout.LabelField("Identifier: " + newstring);

            }
            EditorGUILayout.EndVertical();
            //----------------------------------------------------------------------------->

            //----Remove / Up / Down Buttons-------------------------------------------------->
            EditorGUILayout.BeginVertical();
            if (GUILayout.Button("X", GUILayout.Width(100))) {

                myScript.inputMethods.Remove(_data);
                return null;

            }

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("^", GUILayout.Width(50))) {
                int index = myScript.inputMethods.IndexOf(_data.GetComponent<BaseQInputMethod>());
                if (index != 0) {
                    SwapItems(myScript.inputMethods, index, index - 1);
                }
            }

            if (GUILayout.Button("V", GUILayout.Width(50))) {
                int index = myScript.inputMethods.IndexOf(_data.GetComponent<BaseQInputMethod>());
                if (index != myScript.inputMethods.Count - 1) {
                    SwapItems(myScript.inputMethods, index, index + 1);
                }
            }

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
            //------------------------------------------------------------------------------>

            EditorGUILayout.EndHorizontal();
            return _data;

        }

        public void SwapItems (List<BaseQInputMethod> list, int indexA, int indexB) {

            BaseQInputMethod tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;

        }



    }

}