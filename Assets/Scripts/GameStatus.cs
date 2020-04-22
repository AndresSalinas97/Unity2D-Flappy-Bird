using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public static GameStatus instancia;
    private bool playerAlive = true;

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
}
