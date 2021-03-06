﻿using UnityEngine;

/// <summary>
/// This singleton class keeps track of the player status, which is alive or dead.
/// </summary>
public class PlayerStatusManager : MonoBehaviour
{
    /// <summary>
    /// The one and only instance of PlayerStatusManager.
    /// </summary>
    public static PlayerStatusManager instance;

    /// <summary>
    /// Boolean that keeps the player status.
    /// </summary>
    private bool playerAlive = false;

    /// <summary>
    /// Awake is called after all objects are initialized, before the game
    /// starts.
    /// </summary>
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

    /// <summary>
    /// Start is called just before the first frame update.
    /// </summary>
    private void Start()
    {
        EventsManager.instance.OnGameStarted += SetPlayerAliveTrue;
        EventsManager.instance.OnGameOver += SetPlayerAliveFalse;
    }

    /// <summary>
    /// OnDestroy is called when the game object is destroyed.
    /// </summary>
    private void OnDestroy()
    {
        EventsManager.instance.OnGameStarted -= SetPlayerAliveTrue;
        EventsManager.instance.OnGameOver -= SetPlayerAliveFalse;
    }

    /// <summary>
    /// Returns true if the player is alive.
    /// </summary>
    public bool IsPlayerAlive()
    {
        return playerAlive;
    }

    /// <summary>
    /// Sets playerAlive to true.
    /// </summary>
    private void SetPlayerAliveTrue()
    {
        playerAlive = true;
    }

    /// <summary>
    /// Sets playerAlive to false.
    /// </summary>
    private void SetPlayerAliveFalse()
    {
        playerAlive = false;
    }
}
