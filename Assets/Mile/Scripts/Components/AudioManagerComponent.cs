using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManagerComponent : MonoBehaviour
{
    private AudioMixerGroup musicVolumeMixer;
    private AudioMixerGroup SFXVolumeMixer;
    [SerializeField]private Sound[] sounds;

    // private void Awake() {


    //     foreach (Sound s in sounds) {
    //         s.audioSource = gameObject.AddComponent<AudioSource>();
    //         s.audioSource.clip = s.audioClip;
    //         s.audioSource.loop = s.isLooping;
    //         s.audioSource.volume = s.volume;

    //         switch (s.audioType) {
    //             case Sound.AudioType.music:
    //                 s.audioSource.outputAudioMixerGroup = musicVolumeMixer;
    //                 break;
    //             case Sound.AudioType.SFX:
    //                 s.audioSource.outputAudioMixerGroup = SFXVolumeMixer;
    //                 break;
    //             default:
    //                 break;
    //         }

    //         if (s.playOnAwake) s.audioSource.Play();
    //     }
    // }

    private void Start() {
        musicVolumeMixer = AudioManagerMaster.Instance.musicVolumeMixer;
        SFXVolumeMixer = AudioManagerMaster.Instance.SFXVolumeMixer;

        foreach (Sound s in sounds) {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.audioClip;
            s.audioSource.loop = s.isLooping;
            s.audioSource.volume = s.volume;

        switch (s.audioType) {
            case Sound.AudioType.music:
                s.audioSource.outputAudioMixerGroup = musicVolumeMixer;
                break;
            case Sound.AudioType.SFX:
                s.audioSource.outputAudioMixerGroup = SFXVolumeMixer;
                break;
            default:
                break;
        }

        if (s.playOnAwake) s.audioSource.Play();
        }
    }

    public void Play(string clipname) {
        Sound s = Array.Find(sounds, dummy_sound => dummy_sound.clipName == clipname);
        if  (s == null) {
            print(clipname + " does not exist.");
            return;
        }

        AudioClip audioclip = s.audioSource.clip; //It just works.
        s.audioSource.PlayOneShot(audioclip);
    }

    public void Stop(string clipname) {
        Sound s = Array.Find(sounds, dummy_sound => dummy_sound.clipName == clipname);
        if  (s == null) {
            print(clipname + " does not exist.");
            return;
        }

        s.audioSource.Stop();
    }

    public void Pause(string clipname) {
        Sound s = Array.Find(sounds, dummy_sound => dummy_sound.clipName == clipname);
        if  (s == null) {
            print(clipname + " does not exist.");
            return;
        }

        s.audioSource.Pause();
    }
}
