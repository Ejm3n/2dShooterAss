using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioTrack
{
    public SoundType Type;
    public AudioClip Clip;
    public string Name;
}

public enum SoundType
{
    SOUND_SFX,
    SOUND_MUSIC
}
public class SoundManager : MonoBehaviour
{
    [Header("Put all sounds and sfx here")]
    [SerializeField] private AudioTrack[] audioTracks;

    private Dictionary<string, AudioClip> sfxDictionary = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> musicDictionary = new Dictionary<string, AudioClip>();

    private AudioSource sfxSource;
    private AudioSource musicSource;

    private void Start()
    {
        Initialize();
    } 

    private void Initialize()
    {
        // Create a new GameObject to hold the AudioSource
        sfxSource = gameObject.AddComponent<AudioSource>();


        musicSource = gameObject.AddComponent<AudioSource>();

        musicSource.loop = true;
        foreach (AudioTrack track in audioTracks)
        {
            AddSound(track.Name, track.Clip, track.Type);
        }
        sfxSource.volume = MainController.Instance.DataSaver.GetSFXVolume();
        musicSource.volume = MainController.Instance.DataSaver.GetSoundVolume();
        PlayMusic("BackgroundMusic");
       
    }

    // Add a sound to the dictionary.
    public void AddSound(string soundKey, AudioClip audioClip, SoundType soundType)
    {
        Dictionary<string, AudioClip> targetDictionary = GetDictionaryByType(soundType);

        if (!targetDictionary.ContainsKey(soundKey))
        {
            targetDictionary.Add(soundKey, audioClip);
        }
        else
        {
            Debug.LogWarning("Sound key " + soundKey + " already exists in the " + soundType + " dictionary.");
        }
    }

    // Play a sound by key interface.
    public void PlaySound(string soundKey)
    {
        Play(soundKey, SoundType.SOUND_SFX);
    }
    public void PlaySound(string soundKey,float volume)
    {
        Play(soundKey, SoundType.SOUND_SFX,volume);
    }

    // Play music by key interface.
    public void PlayMusic(string soundKey)
    {
        musicSource.Stop();
        Play(soundKey, SoundType.SOUND_MUSIC);
    }
    public void ChangeSFXVolume()
    {
        float vol = MainController.Instance.UIManager.sfxSlider.value;

        sfxSource.volume = vol;
        MainController.Instance.DataSaver.SaveSFXVolume(vol);
    }
    public void ChangeMusicVolume()
    {
        float vol = MainController.Instance.UIManager.musicSlider.value;
        musicSource.volume = vol;
        MainController.Instance.DataSaver.SaveSoundVolume(vol);
       
        //Debug.Log("music = " + MainController.Instance.DataSaver.GetSoundVolume());
    }
    // Play utility.
    private void Play(string soundKey, SoundType soundType)
    {
        Dictionary<string, AudioClip> targetDictionary;
        AudioSource targetSource;

        SetTargetsByType(soundType, out targetDictionary, out targetSource);

        if (targetDictionary.ContainsKey(soundKey))
        {
            targetSource.PlayOneShot(targetDictionary[soundKey]);
        }
        else
        {
            Debug.LogWarning("Sound key " + soundKey + " not found in the " + soundType + " dictionary.");
        }
    }
    private void Play(string soundKey, SoundType soundType,float volume)
    {
        Dictionary<string, AudioClip> targetDictionary;
        AudioSource targetSource;

        SetTargetsByType(soundType, out targetDictionary, out targetSource);

        if (targetDictionary.ContainsKey(soundKey))
        {
            if(soundType == SoundType.SOUND_SFX)
                targetSource.PlayOneShot(targetDictionary[soundKey],volume*sfxSource.volume);
            else
                targetSource.PlayOneShot(targetDictionary[soundKey], volume * musicSource.volume);
        }
        else
        {
            Debug.LogWarning("Sound key " + soundKey + " not found in the " + soundType + " dictionary.");
        }
    }

    private void SetTargetsByType(SoundType soundType, out Dictionary<string, AudioClip> targetDictionary, out AudioSource targetSource)
    {
        switch (soundType)
        {
            case SoundType.SOUND_SFX:
                targetDictionary = sfxDictionary;
                targetSource = sfxSource;
                break;
            case SoundType.SOUND_MUSIC:
                targetDictionary = musicDictionary;
                targetSource = musicSource;
                break;
            default:
                Debug.LogError("Unknown sound type: " + soundType);
                targetDictionary = null;
                targetSource = null;
                break;
        }
    }
    private Dictionary<string, AudioClip> GetDictionaryByType(SoundType soundType)
    {
        switch (soundType)
        {
            case SoundType.SOUND_SFX:
                return sfxDictionary;
            case SoundType.SOUND_MUSIC:
                return musicDictionary;
            default:
                Debug.LogError("Unknown sound type: " + soundType);
                return null;
        }
    }
}