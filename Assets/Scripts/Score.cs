using System.Collections;
using System.Collections.Generic;
using UnityEngine;

# pragma warning disable 649 // Para desactivar warnings por los SerializeFields

public class Score : MonoBehaviour
{
    private int score = 0;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GameStatus.instancia.IsPlayerAlive())
        {
            EventsManager.instance.Score();

            score++;
            SoundManager.instance.PlaySound(SoundManager.SoundClips.FBCoin);
            Debug.Log("Score: " + score);
        }
    }
}
