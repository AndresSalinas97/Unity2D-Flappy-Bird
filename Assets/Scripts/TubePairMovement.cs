using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubePairMovement : MonoBehaviour
{
    private const float SPEED = 3f;
    private const float LIMITE_X = -5.5f;

    void Update()
    {
        if (PlayerStatusManager.instance.IsPlayerAlive())
        {
            transform.position += Vector3.left * SPEED * Time.deltaTime;

            if (transform.position.x < LIMITE_X)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
