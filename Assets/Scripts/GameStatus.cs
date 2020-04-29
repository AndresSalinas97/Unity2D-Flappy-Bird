using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public static GameStatus instancia;
    private bool playerAlive = false;

    private void Start()
    {
        EventsManager.instance.OnStartGame += SetPlayerLive;
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
        if (GameStatus.instancia != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            GameStatus.instancia = this;
        }
    }

    private void SetPlayerLive()
    {
        SetPlayerAlive(true);
    }
}
