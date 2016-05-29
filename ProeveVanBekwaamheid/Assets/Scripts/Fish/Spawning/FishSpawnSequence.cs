using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Base.Manager;
using Base.Game.Fish;
using Base.Game.Hooks;
namespace Base.Game.Fish{

	public class FishSpawnSequence: MonoBehaviour {
        
		public FishBundle fishBundle;
	    public FishCreation fishCreator;
		private SequenceController sequenceController;

	    public List<FishBehaviour> redFishes;
	    private int redInUse;
	    public List<FishBehaviour> greenFishes;
	    private int greenInUse;
	    public List<FishBehaviour> yellowFishes;
	    private int yellowInUse;

	    private FishBundleController _parent;

	    public void Init(FishBundleController _parent) {
			
	        this._parent = _parent;
	        sequenceController = SequenceController.Instance;

	        this.fishBundle = _parent._fishBundle;
	        this.fishCreator = _parent._fishCreation;

	    }

	    public bool WaveStart(int _targetLevel) {
			
	        ResetScores();
	        SetSequence(_targetLevel);
            return true;

	    }

	    private void SetSequence(int targetLevel) {
			
	        if (targetLevel > sequenceController.StartGameSequence.Count) {
				
	            sequenceController.CreateNewRandomSequence();
	            SetSequence(targetLevel);

	        } else {
				
	            FishSequence tempColors = sequenceController.StartGameSequence[targetLevel];
	            StartSequence(tempColors);

	        }

	    }

		private void StartSequence(FishSequence _targetSequence) {
			
	        for (int i = 0;i < _targetSequence.availableFishColors.Count;i++)
	            AddFishToBundle(_targetSequence.availableFishColors[i]);

	    }

		private void AddFishToBundle(ColorEnum _targetColor) {
			
	        switch (_targetColor) {

	            case ColorEnum.GREEN:
	            if (greenInUse >= greenFishes.Count) {

                    fishCreator.CreateFish(_targetColor,true);

	            } else {

                    fishBundle.availableFish.Add(greenFishes[greenInUse]);
                    greenInUse++;

	            }
	            break;

	            case ColorEnum.RED:
	            if (redInUse >= redFishes.Count) {

                    fishCreator.CreateFish(_targetColor,true);

	            } else {

                    fishBundle.availableFish.Add(redFishes[redInUse]);
                    redInUse++;

	            }
				break;

	            case ColorEnum.YELLOW:
	            if (yellowInUse >= yellowFishes.Count) {

                    fishCreator.CreateFish(_targetColor,true);

	            } else {

                    fishBundle.availableFish.Add(yellowFishes[yellowInUse]);
                    yellowInUse++;

	            }

	            break;

	        }

	    }

	    private void ResetScores() {
			
	        redInUse = 0;
	        greenInUse = 0;
	        yellowInUse = 0;

	    }

	}

}
