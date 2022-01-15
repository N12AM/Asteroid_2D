using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioSource _audioSource;
    private static Dictionary<AudioClipName, AudioClip> _audioClips = new Dictionary<AudioClipName, AudioClip>();
    
    /// <summary>
    /// initializes the audio clips in a Dictionary. With a enumeration Key and a clip path as value
    /// </summary>
    /// <param name="source"></param>
    public static void Initialize(AudioSource source)
    {
        _audioSource = source;
        
        try
        {
            _audioClips.Add(AudioClipName.PlayerShot , Resources.Load<AudioClip>("PlayerShoot"));
            _audioClips.Add(AudioClipName.PlayerDied, Resources.Load<AudioClip>("PlayerDied"));
            _audioClips.Add(AudioClipName.AsteroidBlast, Resources.Load<AudioClip>("AsteroidBlast"));
        }
        catch (Exception e)
        {
            print(e);
            throw;
        }
        
    }

    /// <summary>
    /// Plays the audio clip if the enumeration key exists. Throws a exception if key not found.
    /// </summary>
    /// <param name="audioClipName"></param>
    public static void Play(AudioClipName audioClipName)
    {
        try
        {
            _audioSource.PlayOneShot(_audioClips[audioClipName]);
        }
        catch (Exception e)
        {
            print(e.StackTrace);
            throw;
        }
    }
}
