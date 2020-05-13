using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int score = 0;

    private void Start()
    {
        EventsManager.instance.OnGameStarted += ResetScore;
        EventsManager.instance.OnTubesCrossed += IncreaseScore;
    }

    private void Awake()
    {
        if (ScoreManager.instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            ScoreManager.instance = this;
        }
    }

    public int GetScore()
    {
        return score;
    }

    private void IncreaseScore()
    {
        score++;
    }

    private void ResetScore()
    {
        score = 0;
    }
}
