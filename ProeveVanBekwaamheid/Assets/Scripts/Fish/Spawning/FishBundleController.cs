﻿using UnityEngine;
using System.Collections;
using Base.Game.FishSpawning;

public class FishBundleController: Singleton<FishBundleController> {

    public FishCreation _fishCreation;
    public FishBundle _fishBundle;
    public FishSpawnSequence _fishSpawnSequence;

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
