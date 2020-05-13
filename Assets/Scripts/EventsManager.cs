using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager instance;

    private void Awake()
    {
        if (EventsManager.instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            EventsManager.instance = this;
        }
    }

    public event Action OnGameStarted;
    public void GameStarted()
    {
        OnGameStarted?.Invoke();
    }

    public event Action OnTubesCrossed;
    public void TubesCrossed()
    {
        OnTubesCrossed?.Invoke();
    }

    public event Action OnGameOver;
    public void GameOver()
    {
        OnGameOver?.Invoke();
    }
}
