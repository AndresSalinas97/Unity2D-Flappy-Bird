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
    /// Start is called just before the first frame update.
    /// </summary>
    private void Start()
    {
        EventsManager.instance.OnGameStarted += LoadInGameScene;
    }

    private void OnDestroy()
    {
        EventsManager.instance.OnGameStarted -= LoadInGameScene;
    }

    public void LoadInGameScene()
    {
        SceneManager.LoadScene("InGame");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
