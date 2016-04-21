using UnityEngine;
using System.Collections;

public class VarsController : Singleton<VarsController> {
    public int score;
    public int timeInSeconds;

    public ScoreShowerBehaviour scoreShower;
    void Start()
    {
        StartCoroutine("TimeUpdate");
    }
    public void AddToScore(float add)
    {
        score += (int)add;
    }
    
    public IEnumerator TimeUpdate()
    {
        if (timeInSeconds > 0)
        {
            timeInSeconds -= 1;
            yield return new WaitForSeconds(1);
            StartCoroutine("TimeUpdate");
            yield break;
        }
    }
    public string GetScoreInString()
    {
        return score.ToString() + " pt";
    }

    public string GetTimeInString()
    {
        int minutes;
        int seconds;
        minutes = timeInSeconds / 60;
        seconds = timeInSeconds % 60;
        if (seconds < 10)
        {
            return minutes + " : 0" + seconds;
        }
        else
        {
            return minutes + " : " + seconds;
        }
    }


}
