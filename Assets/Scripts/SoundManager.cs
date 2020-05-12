using System.Collections;
using System.Collections.Generic;
using UnityEngine;

# pragma warning disable 649 // Para desactivar warnings por los SerializeFields

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] List<AudioClip> audioClips;
    
    private AudioSource audioSource;
    public enum SoundClips
    {
        Flap,
        Coin,
        Crash,
    }

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

    private void Start()
	{
        audioSource = GetComponent<AudioSource>();
	}

    public void PlaySound(SoundClips clip)
	{
        audioSource.PlayOneShot(getAudioClip(clip));
	}

    private AudioClip getAudioClip(SoundClips clip)
	{
        foreach (AudioClip a in audioClips)
		{
            if(a.name == clip.ToString())
            {
                return a;
			}
		}

        return null;
	}

    public void SetVolume(float volumeLevel)
    {
        audioSource.volume = volumeLevel;
    }
}
