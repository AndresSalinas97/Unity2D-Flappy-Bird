using System.Collections;
using System.Collections.Generic;
using UnityEngine;

# pragma warning disable 649 // Para desactivar warnings por los SerializeFields

public class FloorScrollParallax : MonoBehaviour
{
    private const float SPEED = 0.37f;

    [SerializeField] Material m;

    void Update()
    {
        if (GameStatus.instancia.IsPlayerAlive())
        {
            m.mainTextureOffset += new Vector2(Time.deltaTime * SPEED, 0);
        }
    }
}
