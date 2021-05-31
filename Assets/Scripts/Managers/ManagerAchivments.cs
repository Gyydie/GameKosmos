using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAchivments : MonoBehaviour
{


    private void OnEnable()
    {
        ManagerScore.OnNewScore += CheckAchivments;
    }

    private void OnDisable()
    {
        ManagerScore.OnNewScore -= CheckAchivments;
    }

    private void CheckAchivments(int newScore)
    {
        if(newScore > 9)
        {
            Debug.Log("You are the CHAMPION!");
        }
    }
}
