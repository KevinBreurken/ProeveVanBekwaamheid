using UnityEngine;
using UnityEditor;
using System.Collections;
using Base.Game.Fish;


/// <summary>
/// Custom editor that sets the fish back in a sequence.
/// </summary>
[CustomEditor(typeof(SetFishInSequence))]
public class SetFishInSequenceEditor: Editor {

    public override void OnInspectorGUI() {

        SetFishInSequence myTarget = (SetFishInSequence)target;
        if (GUILayout.Button("Set Sequence")) {
            Debug.Log("<color=blue>[REVEIVING DATA]</color>");
            myTarget.SetFunctionality();

        }
    }
}
