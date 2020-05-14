using UnityEngine;

/// <summary>
/// This singleton class ensures that there is only one GameManagers object and
/// that it is not destroyed when loading a different scene.
/// </summary>
public class GameManagers : MonoBehaviour
{
    /// <summary>
    /// The one and only instance of the GameManagers.
    /// </summary>
    public static GameManagers instance;

    /// <summary>
    /// Awake is called after all objects are initialized, before the game
    /// starts.
    /// </summary>
    private void Awake()
    {
        if (GameManagers.instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            GameManagers.instance = this;
        }

        // Don't let this object be destroyed when loading a different scene.
        DontDestroyOnLoad(this.gameObject);
    }
}
