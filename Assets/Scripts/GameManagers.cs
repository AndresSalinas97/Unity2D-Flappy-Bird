using UnityEngine;

/// <summary>
/// This class ensures that there is only one GameManagers object and that it is
/// not destroyed when loading a different scene.
/// </summary>
public class GameManagers : MonoBehaviour
{
    /// <summary>
    /// The one and only instance of the GameManagers.
    /// </summary>
    public static GameManagers instance;

    /// <summary>
    /// Awake is called after all objects are initialized, before the game
    /// starts. It sets the instance value to reference this instance or
    /// destroys this object in case it's already set.
    /// </summary>
    private void Awake()
    {
        if(GameManagers.instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            GameManagers.instance = this;
        }
    }

    /// <summary>
    /// Start is called just before the first frame update.
    /// </summary>
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
