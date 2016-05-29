using UnityEngine;
using UnityEditor;
using System.Collections;
using Base.Game.Fish;


[CustomEditor(typeof(SetFishInSequence))]
public class SetFishInSequenceEditor: Editor {

    public override void OnInspectorGUI() {

        SetFishInSequence myTarget = (SetFishInSequence)target;
        if (GUILayout.Button("Set Sequence")) {
            Debug.Log("[Sequence Set]");
            myTarget.SetFunctionality();

        }
    }
}
