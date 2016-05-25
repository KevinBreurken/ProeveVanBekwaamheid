using UnityEngine;
using System.Collections;

public class FishBundleController : Singleton<FishBundleController> {

    public FishCreation _fishCreation;
    public FishBundle _fishBundle;
    public FishSpawnSequence _fishSpawnSequence;
    
    void Init()
    {
        _fishCreation = GetComponent<FishCreation>();
        _fishBundle = GetComponent<FishBundle>();
        _fishSpawnSequence = GetComponent<FishSpawnSequence>();

        _fishBundle.Init(this);
        _fishSpawnSequence.Init(this);

    }

    void Start()
    {
        Init();
    }
}
