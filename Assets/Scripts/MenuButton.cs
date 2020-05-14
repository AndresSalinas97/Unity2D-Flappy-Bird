using UnityEngine;

/// <summary>
/// Contains the menu button actions.
/// </summary>
public class MenuButton : MonoBehaviour
{
    /// <summary>
    /// Loads the Menu scene.
    /// </summary>
    public void LoadMenuScene()
    {
        SceneChanger.instance.LoadMenuScene();
    }
}
