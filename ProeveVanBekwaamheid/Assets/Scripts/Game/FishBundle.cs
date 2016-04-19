using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Chanisco;
public class FishBundle : MonoBehaviour
{
    public List<FishBehaviour> availableFish = new List<FishBehaviour>();

    private VarsController varsController;
    private Area seaArea;

    void Start()
    {
        varsController = VarsController.Instance;
        seaArea = varsController.SeaField;
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
        float randomY = Random.Range(seaArea.yTop, seaArea.yBottom + seaArea.yTop);
        Debug.Log(seaArea.yTop + " " + (seaArea.yBottom + seaArea.yTop) + " " + randomY);
        switch (randomNumber)
        {
            case 0:
                targetFish.ownDirection = Direction.RIGHT;
                targetFish.fishArea = seaArea;
                targetFish.ActivateFish(new Vector2(seaArea.xLeft, randomY));
            break;
            case 1:
                targetFish.ownDirection = Direction.LEFT;
                targetFish.fishArea = seaArea;
                targetFish.ActivateFish(new Vector2(seaArea.xRight, randomY));
            break;
        }
    }
}
