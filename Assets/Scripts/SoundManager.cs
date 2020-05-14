using System.Collections.Generic;
using UnityEngine;

# pragma warning disable 649  // To disable SerializeField warnings

/// <summary>
/// This singleton class 
/// </summary>
public class SoundManager : MonoBehaviour
{
    /// <summary>
    /// The one and only instance of SoundManager.
    /// </summary>
    public static SoundManager instance;

    /// <summary>
    /// List with the audio clips that will be played.
    /// </summary>
    [SerializeField] List<AudioClip> audioClips;

    /// <summary>
    /// An enumeration with the names of the sound effects available in the
    /// audioClips list.
    /// </summary>
    public enum SoundEffect
    {
        Flap,
        Coin,
        Crash,
    }

    /// <summary>
    /// The AudioSource.
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Awake is called after all objects are initialized, before the game
    /// starts.
    private void Awake()
    {
        if(SoundManager.instance != null)
		{
            Destroy(this.gameObject);
		}
        else
		{
            SoundManager.instance = this;
		}
	}

    /// <summary>
    /// Start is called just before the first frame update.
    /// </summary>
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
	}

    /// <summary>
    /// Plays the audio clip with the specified soundEffect.
    /// </summary>
    /// <param name="soundEffect">The SoundEffect that will be played.</param>
    public void PlaySound(SoundEffect soundEffect)
	{
        audioSource.PlayOneShot(GetAudioClip(soundEffect));
	}

    /// <summary>
    /// Returns the audio clip with the specified soundEffect.
    /// </summary>
    /// <param name="soundEffect">The SoundEffect that will be returned.</param>
    private AudioClip GetAudioClip(SoundEffect soundEffect)
	{
        foreach (AudioClip i in audioClips)
		{
            if(i.name == soundEffect.ToString())
            {
                return i;
			}
		}

        return null;
	}

    /// <summary>
    /// Sets the volume level.
    /// </summary>
    /// <param name="volumeLevel">The volume level (from 0 to 1).</param>
    public void SetVolumeLevel(float volumeLevel)
    {
        audioSource.volume = volumeLevel;
    }

    /// <summary>
    /// Returns the current volume level.
    /// </summary>
    public float GetVolumeLevel()
    {
        return audioSource.volume;
    }
}
