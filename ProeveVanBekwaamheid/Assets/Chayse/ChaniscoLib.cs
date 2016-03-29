using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

public static class ChaniscoLib
{
    /// <summary>
    /// A mini shuffle that 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="iList"></param>
    public static void Shuffle<T>(this List<T> iList)
    {
        int n = iList.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(n, 1);
            T value = iList[k];
            iList[k] = iList[n];
            iList[n] = value;
        }
    }

    /// <summary>
    /// Shuffle a target list...but then HARD >: P
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="iList"></param>
    public static void HeavyShuffle<T>(this List<T> iList)
    {
        RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        int n = iList.Count;
        while (n > 1)
        {
            byte[] box = new byte[1];
            do provider.GetBytes(box);
            while (!(box[0] < n * (byte.MaxValue / n)));
            int k = (box[0] % n);
            n--;
            T value = iList[k];
            iList[k] = iList[n];
            iList[n] = value;
        }
    }

    /// <summary>
    /// changes all the speeds in the target animation
    /// </summary>
    /// <param name="target">Target Animation-Component that you want to change</param>
    /// <param name="targetspeed">the speed you want it to change to(between 0 - 1)</param>
    public static void ChangeAnimationSpeed(this Animation target,float targetspeed)
    {
        foreach (AnimationState state in target)
        {
            state.speed = targetspeed;
        }
    }
    /// <summary>
    /// Changes the targetAnimation to another animation that is in the Animation Array of the object
    /// </summary>
    /// <param name="target">Target Animation-Component that you want to change</param>
    /// <param name="targetAnimation">Target animation that you want to change TO</param>
    public static void ChangeAnimationClip(this Animation target, string targetAnimation)
    {
        if(target.clip.name == targetAnimation)
        {
            return;
        }
        foreach (AnimationState state in target)
        {
            if (state.name == targetAnimation)
            {
                target.clip = state.clip;
                target.Play(targetAnimation);
                break;
            }
        }
    }

    public static int AddWithMax(int target,int addingValue,int maxValue,int minValue)
    {
        int solution = (target + addingValue);
        if (solution > maxValue)
        {
            return maxValue;
        }
        else if(solution < minValue)
        {
            return minValue;
        }
        else
        {
            return solution;
        }
    }

    public static int AddWithMax(float target, int addingValue, int maxValue, int minValue)
    {
        int solution = (int)target + addingValue;
        if (solution > maxValue)
        {
            return maxValue;
        }
        else if (solution < minValue)
        {
            return minValue;
        }
        else
        {
            return solution;
        }
    }

    public static Vector3 SmoothVector3Step(Vector3 target, Vector3 targetVector, float speed)
    {
        Vector3 solution;
        solution.x = Mathf.SmoothStep(target.x, targetVector.x, speed);
        solution.y = Mathf.SmoothStep(target.y, targetVector.y, speed);
        solution.z = Mathf.SmoothStep(target.z, targetVector.z, speed);
        return solution;
    }

    public static Vector2 SmoothVector2Step(Vector2 target, Vector2 targetVector, float speed)
    {
        Vector2 solution;
        solution.x = Mathf.SmoothStep(target.x, targetVector.x, speed);
        solution.y = Mathf.SmoothStep(target.y, targetVector.y, speed);
        return solution;
    }
}
