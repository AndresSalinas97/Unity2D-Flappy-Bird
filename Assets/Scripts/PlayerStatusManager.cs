using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusManager : MonoBehaviour
{
    public static PlayerStatusManager instance;
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
        if (PlayerStatusManager.instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            PlayerStatusManager.instance = this;
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
