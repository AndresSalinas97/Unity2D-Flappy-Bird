using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class ensures that there is only one GameManagers object and that it is
/// not destroyed when loading a different scene.
/// </summary>
public class GameManagers : MonoBehaviour
{
    public static GameManagers instance;

    private void Awake()
    {
        if(GameManagers.instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            GameManagers.instance = this;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
