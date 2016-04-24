using UnityEngine;
using System.Collections;


public class ScoreManager : InGameObject {

    public int currentScore;

    public void AddScore (int _value) {

        currentScore += _value;

    }

    public void ResetScore () {

        currentScore = 0;

    }

    public int GetScore () {

        return currentScore;

    }

    public override void Load () {

        base.Load();
        //Game is loaded. reset the score.
        ResetScore();

    }

}
