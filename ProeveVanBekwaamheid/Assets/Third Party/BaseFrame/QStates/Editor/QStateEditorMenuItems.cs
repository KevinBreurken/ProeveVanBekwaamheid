using UnityEngine;
using System.Collections;
using UnityEditor;
using Base.CustomEditor;
using QStates;

namespace QStates.Editors {

    public class QStateEditorMenuItems {

        [MenuItem("BaseFrame/QState/Create GameState")]
        static void CreateGameState () {

            if (Selection.activeGameObject != null) {
                 
                GameObject obj = Selection.activeGameObject;

                if (obj.GetComponent<GameStateSelector>()) {

                    GameStateSelector selector = obj.GetComponent<GameStateSelector>();

                    GameObject go = EditorCustomUtility.CreateGameObjectInEditor("New GameState");

                    go.AddComponent<BaseGameState>();
                    selector.AddState(go);

                } else {

                    Debug.LogError("Cant create state because the selected GameObject is not the GameStateSelector.");

                }

            } else {

                Debug.LogError("Cant create state because no GameObject is select. select the GameObject with the GameStateSelector component.");

            }

        }

        [MenuItem("BaseFrame/QState/Create UIState")]
        static void CreateUIState () {

            if (Selection.activeGameObject != null) {

                GameObject obj = Selection.activeGameObject;

                if (obj.GetComponent<UIStateSelector>()) {

                    UIStateSelector selector = obj.GetComponent<UIStateSelector>();

                    GameObject go = EditorCustomUtility.CreateGameObjectInEditor("New UIState");

                    go.AddComponent<BaseUIState>();
                    selector.AddState(go);

                } else {

                    Debug.LogError("Cant create state because the selected GameObject is not the UIStateSelector.");

                }

            } else {

                Debug.LogError("Cant create state because no GameObject is select. select the GameObject with the UIStateSelector component.");

            }

        }

        [MenuItem("BaseFrame/QState/Create UIStateSelector")]
        static void CreateUISelector () {

            if(UIStateSelector.Instance != null) {

                Debug.LogError("UIStateSelector already exists. You can only have one UIStateSelector.");
                Selection.activeGameObject = UIStateSelector.Instance.gameObject;

            } else {

                if (Selection.activeGameObject.GetComponent<Canvas>()) {

                    Selection.activeGameObject.AddComponent<UIStateSelector>();

                } else {

                    Debug.LogError("Selected GameObject needs to be the root of your UI Canvas (Requires Canvas Component).");

                }

            }

        }

        [MenuItem("BaseFrame/QState/Create GameStateSelector")]
        static void CreateGameStateSelector () {

            if (GameStateSelector.Instance != null) {

                Debug.LogError("GameStateSelector already exists. You can only have one GameStateSelector.");
                Selection.activeGameObject = GameStateSelector.Instance.gameObject;

            } else {

                GameObject obj = new GameObject("Game States");
                obj.AddComponent<GameStateSelector>();
                Selection.activeGameObject = obj;

            }

        }

    }

}