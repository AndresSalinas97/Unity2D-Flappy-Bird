using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    void Start()
    {
        EventsManager.instance.OnScore += imprimeAlgo;
    }

    private void imprimeAlgo()
    {
        Debug.Log("Evento llamado");
    }
}
