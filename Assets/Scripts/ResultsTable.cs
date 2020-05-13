using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

# pragma warning disable 649  // To disable SerializeField warnings

public class ResultsTable : MonoBehaviour
{
    [SerializeField] Sprite coinBronze, coinSilver, coinGold;
    [SerializeField] Image coinImage;
    [SerializeField] Text finalScoreText;

    void Start()
    {
        EventsManager.instance.OnGameOver += SpawnResults;
    }

    private void OnDestroy()
    {
        EventsManager.instance.OnGameOver -= SpawnResults;
    }

    private void SpawnResults()
	{
        int finalScore = GameStats.instance.GetScore();

        if (finalScore < 5)
        {
            coinImage.sprite = coinBronze;
        }
        else if (finalScore >= 5 && finalScore < 10)
        {
            coinImage.sprite = coinSilver;
        }
        else
        {
            coinImage.sprite = coinGold;
        }

        finalScoreText.text = finalScore.ToString();
    }
}
