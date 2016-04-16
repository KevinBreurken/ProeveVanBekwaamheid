using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Chanisco;
public class FishBundle : MonoBehaviour
{
    public List<FishBehaviour> availableFish = new List<FishBehaviour>();

    private VarsController varsController;
    private Area fishArea;

    void Start()
    {
        varsController = VarsController.Instance;
        fishArea = varsController.fishField;
        availableFish.HeavyShuffle();
        StartCoroutine("SpawnFish");
    }

    IEnumerator SpawnFish()
    {
        ChooseFish();
         yield return new WaitForSeconds(1);
        StartCoroutine("SpawnFish");
    }

    void ChooseFish()
    {
        for (int i = 0; i < availableFish.Count;i++)
        {
            if(availableFish[i].gameObject.activeSelf == false)
            {
                ActivateFish(availableFish[i]);
                break;
            }
        }
    }

    void ActivateFish(FishBehaviour targetFish)
    {
        int randomNumber = Random.Range(0,2);
        float randomY = Random.Range(fishArea.yTop, fishArea.yBottom + fishArea.yTop);
        Debug.Log(fishArea.yTop + " " + (fishArea.yBottom + fishArea.yTop) + " " + randomY);
        switch (randomNumber)
        {
            case 0:
                targetFish.ownDirection = Direction.RIGHT;
                targetFish.fishArea = fishArea;
                targetFish.ActivateFish(new Vector2(fishArea.xLeft, randomY));
            break;
            case 1:
                targetFish.ownDirection = Direction.LEFT;
                targetFish.fishArea = fishArea;
                targetFish.ActivateFish(new Vector2(fishArea.xRight, randomY));
            break;
        }
    }
}
