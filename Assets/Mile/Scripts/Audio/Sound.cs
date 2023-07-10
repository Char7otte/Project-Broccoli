using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public enum AudioType {music, SFX}
    public AudioType audioType;

    [HideInInspector]public AudioSource audioSource;
    public string clipName;
    public AudioClip audioClip;
    public bool playOnAwake;
    public bool isLooping;

    [Range(0, 1)]
    public float volume = 0.5f;
}
