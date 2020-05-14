using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Contains the volume scrollbar actions.
/// </summary>
public class VolumeScrollbar : MonoBehaviour
{
    /// <summary>
    /// The scrollbar component.
    /// </summary>
    private Scrollbar scrollBar;

    /// <summary>
    /// Start is called just before the first frame update.
    /// </summary>
    private void Start()
    {
        scrollBar = GetComponent<Scrollbar>();
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    private void Update()
    {
        // Update the scrollbar value so it reflects the current volume level
        scrollBar.value = SoundManager.instance.GetVolumeLevel();
    }

    /// <summary>
    /// Sets the volume level to the scrollbar value.
    /// </summary>
    public void SetVolumeLevel()
    {
        SoundManager.instance.SetVolumeLevel(scrollBar.value);
    }
}
