using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);

        EventsManager.instance.OnGameOver += ShowGameOverScreen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowGameOverScreen()
    {
        this.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        EventsManager.instance.OnGameOver -= ShowGameOverScreen;
    }
}
