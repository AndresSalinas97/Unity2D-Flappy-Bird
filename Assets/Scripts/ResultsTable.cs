﻿using UnityEngine;
using UnityEngine.UI;

# pragma warning disable 649  // To disable SerializeField warnings

/// <summary>
/// This class is in charge of showing the results table and all the elements
/// inside it.
/// </summary>
public class ResultsTable : MonoBehaviour
{
    /// <summary>
    /// Minimum score to get the bronze coin.
    /// </summary>
    private const int BRONZE_MIN_SCORE = 5;

    /// <summary>
    /// Minimum score to get the silver coin.
    /// </summary>
    private const int SILVER_MIN_SCORE = 15;

    /// <summary>
    /// Minimum score to get the gold coin.
    /// </summary>
    private const int GOLD_MIN_SCORE = 30;

    /// <summary>
    /// Bronze coin sprite.
    /// </summary>
    [SerializeField] Sprite coinBronze;

    /// <summary>
    /// Silver coin sprinte.
    /// </summary>
    [SerializeField] Sprite coinSilver;

    /// <summary>
    /// Gold coin sprite.
    /// </summary>
    [SerializeField] Sprite coinGold;

    /// <summary>
    /// Image where the coin sprites will be loaded.
    /// </summary>
    [SerializeField] Image coinImage;

    /// <summary>
    /// Text field to show the final score.
    /// </summary>
    [SerializeField] Text finalScoreText;

    /// <summary>
    /// Text field to show the best score.
    /// </summary>
    [SerializeField] Text bestScoreText;

    /// <summary>
    /// Start is called just before the first frame update.
    /// </summary>
    private void Start()
    {
        // Hide the results table until it's time to show it.
        this.gameObject.SetActive(false);

        // Hide the coin image until it's time to show it.
        coinImage.enabled = false;

        EventsManager.instance.OnGameOver += ShowResultsTable;
    }

    /// <summary>
    /// OnDestroy is called when the game object is destroyed.
    /// </summary>
    private void OnDestroy()
    {
        EventsManager.instance.OnGameOver -= ShowResultsTable;
    }

    /// <summary>
    /// Shows the results table and all the elements inside it.
    /// </summary>
    private void ShowResultsTable()
	{
        // Gets the final and best scores
        int finalScore = ScoreManager.instance.GetCurrentScore();
        int bestScore = ScoreManager.instance.GetBestScore();

        // Sets the corresponding coin
        if (finalScore >= BRONZE_MIN_SCORE && finalScore < SILVER_MIN_SCORE)
        {
            coinImage.sprite = coinBronze;
            coinImage.enabled = true;
        }
        else if (finalScore >= SILVER_MIN_SCORE && finalScore < GOLD_MIN_SCORE)
        {
            coinImage.sprite = coinSilver;
            coinImage.enabled = true;
        }
        else if (finalScore >= GOLD_MIN_SCORE)
        {
            coinImage.sprite = coinGold;
            coinImage.enabled = true;
        }

        // Sets the finalScoreText and the bestScoreText
        finalScoreText.text = finalScore.ToString();
        bestScoreText.text = bestScore.ToString();

        // Shows the results table
        this.gameObject.SetActive(true);
    }
}
