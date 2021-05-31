using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerScore : MonoBehaviour
{
    public int Score;

    public TextMeshProUGUI ScoreText;

    public static Action<int> OnAddScore;

    public static Action<int> OnNewScore;

    private void Start()
    {
        if (ScoreText == null)
        {
            Debug.LogError("ManagerScore. ScoreText null");
        }
        else
        {
            ScoreText.text = Score.ToString();
        }
    }

    public void OnEnable()
    {
        OnAddScore += IncreaseScore;
    }

    public void OnDisable()
    {
        OnAddScore -= IncreaseScore;
    }

    public static void AddScore(int scoreDelta)
    {
        OnAddScore?.Invoke(scoreDelta);
    }

    private void IncreaseScore(int scoreDelta)
    {
        Score += scoreDelta;
        ScoreText.text = Score.ToString();

        OnNewScore(Score);
    }
}
