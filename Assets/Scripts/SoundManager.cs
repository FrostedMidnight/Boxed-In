using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static AudioSource managerAudioSource;
    public Slider bgmVolumeSlider;

    // public Slider sfxVolumeSlider;
    public static float bgmVolume;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        managerAudioSource = GetComponent<AudioSource>();

        if(PlayerPrefs.HasKey("bgmVolume")){
            bgmVolumeSlider.value = PlayerPrefs.GetFloat("bgmVolume");
        }
        else{
            bgmVolumeSlider.value = 0.9f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBgmVolume()
    {
        managerAudioSource.volume = bgmVolumeSlider.value;
        PlayerPrefs.SetFloat("bgmVolume", bgmVolumeSlider.value);
    }
}
