using System.Collections;
using System.Collections.Generic;
using UnityEngine;

# pragma warning disable 649 // Para desactivar warnings por los SerializeFields

public class Score : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GameStatus.instancia.IsPlayerAlive())
        {
            GameStats.instance.SetScore(GameStats.instance.GetScore() + 1);
            SoundManager.instance.PlaySound(SoundManager.SoundClips.Coin);
        }
    }
}
