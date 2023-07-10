using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AudioOptionsManager : MonoBehaviour
{
    public static float masterVolume {get; private set;}
    public static float musicVolume { get; private set; }
    public static float SFXVolume {get; private set; }

    [SerializeField]private TextMeshProUGUI masterSliderPercentageText;
    [SerializeField]private Slider masterSlider;
    [SerializeField]private TextMeshProUGUI musicSliderPercentageText;
    [SerializeField]private Slider musicSlider;
    [SerializeField]private TextMeshProUGUI SFXSliderPercentageText;
    [SerializeField]private Slider SFXSlider;

    public void Start() {
        //LoadVolumeSliderOptionsFromSaveData();
    }

    public void OnMasterSliderValueChange() {
        masterVolume = masterSlider.value;
        masterSliderPercentageText.text = ((int)(masterVolume*100)).ToString() +  "%";
        AudioManagerMaster.Instance.UpdateAudioMixer();
        //SaveVolumeSliderOptionsToSaveData();
    }

    public void OnMusicSliderValueChange() {
        musicVolume = musicSlider.value;
        musicSliderPercentageText.text = ((int)(musicVolume*100)).ToString() + "%";
        AudioManagerMaster.Instance.UpdateAudioMixer();
        //SaveVolumeSliderOptionsToSaveData();
    }

    public void OnSFXSliderValueChange() {
        SFXVolume = SFXSlider.value;
        SFXSliderPercentageText.text = ((int)(SFXVolume*100)).ToString() + "%";
        AudioManagerMaster.Instance.UpdateAudioMixer();
        //SaveVolumeSliderOptionsToSaveData();
    }

    public void LoadVolumeSliderOptionsFromSaveData() {
        if (PlayerPrefs.HasKey("MasterSliderVolume")) {
            masterVolume = PlayerPrefs.GetFloat("MasterSliderVolume");
            print("Master volume loaded");
        }
        else {
            print("No master volume saved.");
        }

        if (PlayerPrefs.HasKey("musicSliderVolume")) {
            musicVolume = PlayerPrefs.GetFloat("musicSliderVolume");
            print("Music volume loaded");
        }
        else {
            print("No music volume saved.");
        }

        if (PlayerPrefs.HasKey("SFXSliderVolume")) {
            SFXVolume = PlayerPrefs.GetFloat("SFXSliderVolume");
            print("SFX volume loaded");
        }
        else {
            print("No SFX volume saved.");
        }

        OnMasterSliderValueChange();
        OnMusicSliderValueChange();
        OnSFXSliderValueChange();
        AudioManagerMaster.Instance.UpdateAudioMixer();
    }

    public void SaveVolumeSliderOptionsToSaveData() {
        PlayerPrefs.SetFloat("MasterSliderVolume", masterSlider.value);
        PlayerPrefs.SetFloat("MusicSliderVolume", musicSlider.value);
        PlayerPrefs.SetFloat("SFXSliderVolume", SFXSlider.value);
    }
}
