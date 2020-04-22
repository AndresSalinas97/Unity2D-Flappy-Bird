﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

# pragma warning disable 649 // Para desactivar warnings por los SerializeFields

public class SpawnTubos : MonoBehaviour
{
    private const float MIN_Y = -1.5f;
    private const float MAX_Y = 2.5f;
    private const float TIEMPO_ENTRE_SPAWN = 1.7f;
    private const float POS_X_INICIAL = 6;
    private const float POS_Z_INICIAL = 0;

    [SerializeField] GameObject filaTubo;

    void Start()
    {
        StartCoroutine("Spawn");
    }

    private void Update()
    {
        if (!GameStatus.instancia.IsPlayerAlive())
        {
            StopAllCoroutines();
        }
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            float posY = Random.Range(MIN_Y, MAX_Y);

            Instantiate(
                filaTubo,
                new Vector3(POS_X_INICIAL, posY, POS_Z_INICIAL),
                Quaternion.identity);

            yield return new WaitForSeconds(TIEMPO_ENTRE_SPAWN);

            yield return null;
        }
    }
}
