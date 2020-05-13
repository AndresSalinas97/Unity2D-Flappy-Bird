using System;
using UnityEngine;

/// <summary>
/// This singleton class manages the events.
/// </summary>
public class EventsManager : MonoBehaviour
{
    /// <summary>
    /// The one and only instance of the EventsManager.
    /// </summary>
    public static EventsManager instance;

    /// <summary>
    /// Awake is called after all objects are initialized, before the game
    /// starts. It sets the instance value to reference this instance or
    /// destroys this object in case it's already set.
    /// </summary>
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

    /// <summary>
    /// Event used to signal when the game starts.
    /// </summary>
    public event Action OnGameStarted;

    /// <summary>
    /// Raises the OnGameStarted event.
    /// </summary>
    public void GameStarted()
    {
        OnGameStarted?.Invoke();
    }

    /// <summary>
    /// Event used to signal when the bird crossess a tube pair.
    /// </summary>
    public event Action OnTubesCrossed;

    /// <summary>
    /// Raises the OnTubesCrossed event.
    /// </summary>
    public void TubesCrossed()
    {
        OnTubesCrossed?.Invoke();
    }

    /// <summary>
    /// Event used to signal when the game is over.
    /// </summary>
    public event Action OnGameOver;

    /// <summary>
    /// Raises the OnGameOver event.
    /// </summary>
    public void GameOver()
    {
        OnGameOver?.Invoke();
    }
}
