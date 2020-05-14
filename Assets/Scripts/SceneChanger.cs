using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This singleton class helps with loading a different scene.
/// </summary>
public class SceneChanger : MonoBehaviour
{
    /// <summary>
    /// The one and only instance of SceneChanger.
    /// </summary>
    public static SceneChanger instance;

    /// <summary>
    /// Awake is called after all objects are initialized, before the game
    /// starts. It sets the instance value to reference this instance or
    /// destroys this object in case it's already set.
    /// </summary>
    private void Awake()
    {
        if (SceneChanger.instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            SceneChanger.instance = this;
        }
    }

    /// <summary>
    /// Loads the InGame scene and raises the OnGameStarted event.
    /// </summary>
    public void LoadInGameScene()
    {
        SceneManager.LoadScene("InGame");
        EventsManager.instance.GameStarted();
    }

    /// <summary>
    /// Loads the Menu scene.
    /// </summary>
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
