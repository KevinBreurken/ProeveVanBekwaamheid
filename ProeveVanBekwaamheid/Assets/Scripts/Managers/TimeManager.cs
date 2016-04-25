﻿using UnityEngine;
using System.Collections;
using Base.Game;

public class TimeManager : InGameObject {

    public delegate void TimeEvent ();

    public event TimeEvent onTimerEnded;

    public int levelLenght;

    public override void Load () {
        base.Load();
        //Start the timer
    }

    public void StartTimer () {

        StartCoroutine(WaitTillLevelEnds());

    }

    private IEnumerator WaitTillLevelEnds () {

        Debug.Log("Timer started");

        yield return new WaitForSeconds(levelLenght);

        Debug.Log("Timer ended");

        //Send the message that the game time has ended.
        if (onTimerEnded != null) {
            
            onTimerEnded();

        }

    }

    public override void Unload () {

        StopCoroutine(WaitTillLevelEnds());
        base.Unload();

    }

}
