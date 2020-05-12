using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTubePair : MonoBehaviour
{
    private const float SPEED = 3f;
    private const float LIMITE_X = -4.5f;

    void Update()
    {
        if (GameStatus.instancia.IsPlayerAlive())
        {
            transform.position += Vector3.left * SPEED * Time.deltaTime;

            if (transform.position.x < LIMITE_X)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
