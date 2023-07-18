using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManagerMaster : MonoBehaviour
{
    public static AudioManagerMaster Instance;

    public AudioMixerGroup masterVolumeMixer;
    public AudioMixerGroup musicVolumeMixer;
    public AudioMixerGroup SFXVolumeMixer;
    [SerializeField]private Sound[] sounds = default;

    private void Awake() {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;

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
        
        //s.audioSource.Play();
        AudioClip audioclip = s.audioSource.clip;
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

    // public void UpdateAudioMixer() {
    //     masterVolumeMixer.audioMixer.SetFloat("Master", Mathf.Log10(AudioOptionsManager.masterVolume) * 20);
    //     musicVolumeMixer.audioMixer.SetFloat("Music", Mathf.Log10(AudioOptionsManager.musicVolume) * 20);
    //     SFXVolumeMixer.audioMixer.SetFloat("SFX", Mathf.Log10(AudioOptionsManager.SFXVolume) * 20);
    // }

}
