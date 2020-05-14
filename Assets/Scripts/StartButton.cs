using UnityEngine;

/// <summary>
/// Contains the start button actions.
/// </summary>
public class StartButton : MonoBehaviour
{
    /// <summary>
    /// Loads the InGame scene.
    /// </summary>
    public void StartGame()
    {
        SceneChanger.instance.LoadInGameScene();
    }
}
