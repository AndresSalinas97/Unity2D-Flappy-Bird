using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Shows the current score in the score text field.
/// </summary>
public class ScoreText : MonoBehaviour
{
    /// <summary>
    /// The Text object where the current score will be shown.
    /// </summary>
    private Text scoreText;

    /// <summary>
    /// Start is called just before the first frame update.
    /// </summary>
    private void Start()
    {
        EventsManager.instance.OnGameOver += HideScore;

        scoreText = GetComponent<Text>();
    }

    /// <summary>
    /// OnDestroy is called when the game object is destroyed.
    /// </summary>
    private void OnDestroy()
    {
        EventsManager.instance.OnGameOver -= HideScore;
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    private void Update()
    {
        scoreText.text = ScoreManager.instance.GetCurrentScore().ToString();

        // When setting a new record the score text becomes bigger, red and bold
        if (ScoreManager.instance.SettingRecord())
        {
            scoreText.color = Color.red;
            scoreText.fontStyle = FontStyle.Bold;
            scoreText.fontSize = 120;
        }
    }

    /// <summary>
    /// Hides the current score field.
    /// </summary>
    private void HideScore()
    {
        this.gameObject.SetActive(false);
    }
}
