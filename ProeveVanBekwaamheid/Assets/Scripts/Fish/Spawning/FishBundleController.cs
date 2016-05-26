using UnityEngine;
using System.Collections;
using Base.Game.FishSpawning;

public class FishBundleController: Singleton<FishBundleController> {

    /// <summary>
    /// Functions to create new fishes into the game
    /// </summary>
    public FishCreation _fishCreation;
    /// <summary>
    /// Bundle holding the available fish
    /// </summary>
    public FishBundle _fishBundle;
    /// <summary>
    /// Sequence for the spawning of the fishes in the current wave
    /// </summary>
    public FishSpawnSequence _fishSpawnSequence;

    /// <summary>
    /// Init that sets the variables on start
    /// </summary>
    void Init() {
        _fishCreation = GetComponent<FishCreation>();
        _fishBundle = GetComponent<FishBundle>();
        _fishSpawnSequence = GetComponent<FishSpawnSequence>();

        _fishBundle.Init(this);
        _fishSpawnSequence.Init(this);

    }

    void Start() {
        Init();
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.O)) {
            SequenceController.Instance.CreateNewRandomSequence();
        }

    }
}
