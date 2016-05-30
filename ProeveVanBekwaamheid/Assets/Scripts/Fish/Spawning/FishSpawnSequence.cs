using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Base.Manager;
using Base.Game.Fish;
using Base.Game.Hooks;
namespace Base.Game.Fish{

    /// <summary>
    /// The sequence that has the information for all the predetermined waves
    /// </summary>
    public class FishSpawnSequence: MonoBehaviour {

        /// <summary>
        /// Bundle holding the available fish
        /// </summary>
        public FishBundle fishBundle;

        /// <summary>
        /// The class that creates the fishes if there isn't enough in the scene
        /// </summary>
	    public FishCreation fishCreator;

        /// <summary>
        /// The Sequence of the fishes in the waves
        /// </summary>
		private SequenceController sequenceController;

        /// <summary>
        /// The TargetAmount of redFishes in the scene
        /// </summary>
	    public List<FishBehaviour> redFishes;

        /// <summary>
        /// The amount of red fishes in use
        /// </summary>
	    private int redInUse;

        /// <summary>
        /// The TargetAmounf ot greenFishes in the scene
        /// </summary>
	    public List<FishBehaviour> greenFishes;

        /// <summary>
        /// The amount of green fishes in use
        /// </summary>
	    private int greenInUse;

        /// <summary>
        /// The TargetAmount of yellowFishes in the scene
        /// </summary>
	    public List<FishBehaviour> yellowFishes;

        /// <summary>
        /// The amount of yellow fishes in use
        /// </summary>
	    private int yellowInUse;


        /// <summary>
        /// Init that sets the variables on start
        /// </summary>
        public void Init(FishBundleController _parent) {
			
	        sequenceController = SequenceController.Instance;

	        this.fishBundle = _parent.fishBundle;
	        this.fishCreator = _parent.fishCreation;

	    }

        /// <summary>
        /// The functionality that calls upon the sequence for the target wave
        /// </summary>
        /// <param name="_targetLevel">The target wave</param>
        /// <returns></returns>
	    public bool WaveStart(int _targetLevel) {
			
	        ResetScores();
	        SetSequence(_targetLevel);
            return true;

	    }

        /// <summary>
        /// Sets the Sequence ready for the target wave
        /// </summary>
        /// <param name="targetLevel">The target wave</param>
	    private void SetSequence(int targetLevel) {
			
	        if (targetLevel > sequenceController.StartGameSequence.Count) {
				
	            sequenceController.CreateNewRandomSequence();
	            SetSequence(targetLevel);

	        } else {
				
	            FishSequence tempColors = sequenceController.StartGameSequence[targetLevel];
	            StartSequence(tempColors);

	        }

	    }

        /// <summary>
        /// Starts theh sequence for the target wave
        /// </summary>
        /// <param name="_targetSequence">The target Sequence</param>
		private void StartSequence(FishSequence _targetSequence) {
			
	        for (int i = 0;i < _targetSequence.availableFishColors.Count;i++)
	            AddFishToBundle(_targetSequence.availableFishColors[i]);

	    }

        /// <summary>
        /// Adds the target fish into the required bundle
        /// </summary>
        /// <param name="_targetColor">Target fish color</param>
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

        /// <summary>
        /// Resets the scores for the amount of fishes in use
        /// </summary>
	    private void ResetScores() {
			
	        redInUse = 0;
	        greenInUse = 0;
	        yellowInUse = 0;

	    }

	}

}
