using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeScrollbar : MonoBehaviour
{
    private Scrollbar scrollBar;

    private void Start()
    {
        scrollBar = GetComponent<Scrollbar>();
    }

    public void SetVolumeValue()
    {
        SoundManager.instance.SetVolume(scrollBar.value);
    }
}
