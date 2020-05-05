using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            GameManager.instance = this;
        }
    }
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        EventsManager.instance.OnStartGame += NextScene;
    }

    private void NextScene()
    {
        SceneManager.LoadScene("InGame");
    }
}
