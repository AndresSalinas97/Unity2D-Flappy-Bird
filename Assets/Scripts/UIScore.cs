using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    private Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        EventsManager.instance.OnGameOver += hideScore;
    }

    private void Update()
    {
        scoreText.text = GameStats.instance.GetScore().ToString();
    }

    private void OnDestroy()
    {
        EventsManager.instance.OnGameOver -= hideScore;
    }

    private void hideScore()
    {
        this.gameObject.SetActive(false);
    }
}
