using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioSource : MonoBehaviour
{
       private void Awake()
       {
              var audioSource = gameObject.AddComponent<AudioSource>();
              AudioManager.Initialize(audioSource);
       }
}
