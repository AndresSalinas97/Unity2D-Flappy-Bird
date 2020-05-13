using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public static GameStatus instance;
    private bool playerAlive = false;

    private void Start()
    {
        EventsManager.instance.OnGameStarted += SetPlayerAliveTrue;
        EventsManager.instance.OnGameOver += SetPlayerAliveFalse;
    }

    public bool IsPlayerAlive()
    {
        return playerAlive;
    }

    public void SetPlayerAlive(bool playerAlive)
    {
        this.playerAlive = playerAlive;
    }

    private void Awake()
    {
        if (GameStatus.instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            GameStatus.instance = this;
        }
    }

    private void SetPlayerAliveTrue()
    {
        playerAlive = true;
    }

    private void SetPlayerAliveFalse()
    {
        playerAlive = false;
    }
}
