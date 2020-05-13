using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static GameStats instance;

    private int score = 0;

    private void Start()
    {
        EventsManager.instance.OnStartGame += ResetScore;
    }

    private void Awake()
    {
        if (GameStats.instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            GameStats.instance = this;
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int score)
    {
        this.score = score;
    }

    public void IncreaseScore()
    {
        score++;
    }

    private void ResetScore()
    {
        score = 0;
    }
}
