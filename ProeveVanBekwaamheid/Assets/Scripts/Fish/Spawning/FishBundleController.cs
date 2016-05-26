using UnityEngine;
using System.Collections;

namespace Base.Game.Fish {

	public class FishBundleController : Singleton<FishBundleController> {

	    public FishCreation fishCreation;
	    public FishBundle fishBundle;
	    public FishSpawnSequence fishSpawnSequence;
	    
	    void Init() {
			
	        fishCreation = GetComponent<FishCreation>();
	        fishBundle = GetComponent<FishBundle>();
	        fishSpawnSequence = GetComponent<FishSpawnSequence>();

	        fishBundle.Init(this);
	        fishSpawnSequence.Init(this);

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

}
