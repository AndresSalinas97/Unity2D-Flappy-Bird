using UnityEngine;

/// <summary>
/// This class ensures the Game Over screen is only shown when the game is over.
/// </summary>
public class GameOverScreen : MonoBehaviour
{
    /// <summary>
    /// Start is called just before the first frame update.
    /// </summary>
    private void Start()
    {
        EventsManager.instance.OnGameOver += ShowGameOverScreen;

        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// OnDestroy is called when the game object is destroyed.
    /// </summary>
    private void OnDestroy()
    {
        EventsManager.instance.OnGameOver -= ShowGameOverScreen;
    }

    /// <summary>
    /// Shows the Game Over screen.
    /// </summary>
    private void ShowGameOverScreen()
    {
        this.gameObject.SetActive(true);
    }
}
