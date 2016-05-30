using UnityEngine;
using UnityEditor;
using System.Collections;
using BaseFrame.CustomEditor;
using BaseFrame.QEffect;
using BaseFrame.QEffect.Effects;

/// <summary>
/// Custom Editors for QEffect related components.
/// </summary>
namespace BaseFrame.QEffect.Editors {

	/// <summary>
	/// Custom menu items for QEffect.
	/// </summary>
    public class QEffectEditorMenuItems {

        [MenuItem("BaseFrame/QEffect/Build EffectManager")]
        public static void CreateEffectManager () {

            if (Selection.activeGameObject == null) {

                if (EffectManager.Instance != null) {

                    Debug.LogError("EffectManager already exists.");

                } else {

                    GameObject go = EditorCustomUtility.CreateGameObjectInEditor("EffectManager");
                    go.AddComponent<EffectManager>();
                    IntializeEffectManager(go.GetComponent<EffectManager>());

                }

            } else {

                Debug.LogError("GameObject selected. you must have no GameObject selected to create the Effect Manager.");

            }

        }

        private static void IntializeEffectManager (EffectManager _manager) {

            Selection.activeGameObject = _manager.gameObject;

            //Create the FadeEffect Object.
            GameObject fadeEffect = EditorCustomUtility.CreateGameObjectInEditor("FadeEffect");
            fadeEffect.AddComponent<FadeEffect>();
            _manager.FadeEffect = fadeEffect.GetComponent<FadeEffect>();

            Selection.activeGameObject = _manager.gameObject;

            Debug.Log("[Fade Effect]: \n" + 
                "On the fade effect component theres a Canvas Group variable. " + 
                "Add your desired canvasgroup that will be faded by this script.");

            //Create Contrast Setter
            GameObject contrastEffect = EditorCustomUtility.CreateGameObjectInEditor("Contrast Setter");
            contrastEffect.AddComponent<ContrastSetter>();

            Debug.Log("[Contrast Setter]: \n" +
               "On the contrast setter component theres a Camera variable. " +
               "Add your desired camera to that component that will use this contrast component. (the top level camera, probably the UI camera.)");

        }

    }

}