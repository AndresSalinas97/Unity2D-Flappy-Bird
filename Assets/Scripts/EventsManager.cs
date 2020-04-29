using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager instance;

    private void Awake()
    {
        if (EventsManager.instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            EventsManager.instance = this;
        }
    }
}
