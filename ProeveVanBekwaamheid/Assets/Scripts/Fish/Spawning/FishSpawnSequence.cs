using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Base.Manager;

public class FishSpawnSequence : MonoBehaviour {

    public WaveManager _waveManager;
    public FishBundle _fishBundle;
    private SequenceController _sequenceController;
    public FishCreation _fishCreator;

    public List<FishBehaviour> redFishes;
    private int redInUse;
    public List<FishBehaviour> greenFishes;
    private int greenInUse;
    public List<FishBehaviour> yellowFishes;
    private int yellowInUse;

    private FishBundleController _parent;

    public void Init(FishBundleController _parent)
    {
        _parent = this._parent;
        _sequenceController = SequenceController.Instance;
        this._fishBundle = _parent._fishBundle;
        this._fishCreator = _parent._fishCreation;
    }

    public void StartLevel()
    {
        ResetScores();
        SetSequence(_waveManager.currentLevel);
    }

    private void SetSequence(int targetLevel)
    {
        if (targetLevel > _sequenceController.StartGameSequence.Count)
        {
            //TODO Create own LevelSequence
        }
        else
        {
            FishSequence tempColors = _sequenceController.StartGameSequence[targetLevel];
            StartSequence(tempColors);
        }
    }

    private void StartSequence(FishSequence targetSequence)
    {
        for(int i = 0; i < targetSequence.availableFishColors.Count; i++)
        {
            AddFishToBundle(targetSequence.availableFishColors[i]);

        }
    }

    private void AddFishToBundle(HookColors targetColor)
    {
        switch (targetColor)
        {
            case HookColors.GREEN:
                if (greenInUse >= greenFishes.Count)
                {
                    _fishCreator.CreateFish(targetColor,true);
                }
                else
                {
                    _fishBundle.availableFish.Add(greenFishes[greenInUse]);
                    greenInUse++;
                }

            break;
            case HookColors.RED:
                if (redInUse >= redFishes.Count)
                {
                    _fishCreator.CreateFish(targetColor, true);
                }
                else
                {
                    _fishBundle.availableFish.Add(redFishes[redInUse]);
                    redInUse++;
                }

                break;
            case HookColors.YELLOW:
                if (yellowInUse >= yellowFishes.Count)
                {
                    _fishCreator.CreateFish(targetColor, true);
                }
                else
                {
                    _fishBundle.availableFish.Add(yellowFishes[yellowInUse]);
                    yellowInUse++;
                }

                break;
        }
    }

    private void ResetScores()
    {
        redInUse    = 0;
        greenInUse  = 0;
        yellowInUse = 0;
    }
}

