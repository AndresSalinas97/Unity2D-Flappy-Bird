using System.Collections;
using System.Collections.Generic;
using UnityEngine;

# pragma warning disable 649 // Para desactivar warnings por los SerializeFields

public class Score : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    private int score = 0;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GameStatus.instancia.IsPlayerAlive())
        {
            score++;
            audioSource.Play();
            Debug.Log("Score: " + score);
        }
    }
}
