using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static AudioSource managerAudioSource;

    [SerializeField] private Slider bgmVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    
    public static float bgmVolume;
    public static float sfxVolume;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        managerAudioSource = GetComponent<AudioSource>();

        if(PlayerPrefs.HasKey("bgmVolume")){
            bgmVolumeSlider.value = PlayerPrefs.GetFloat("bgmVolume");
        }
        else{
            bgmVolumeSlider.value = 1f;
        }

        if(PlayerPrefs.HasKey("sfxVolume")){
            sfxVolumeSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        }
        else{
            sfxVolumeSlider.value = 1f;
        }

        bgmVolume = bgmVolumeSlider.value;
        sfxVolume = sfxVolumeSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBgmVolume()
    {
        managerAudioSource.volume = bgmVolumeSlider.value;
        bgmVolume = bgmVolumeSlider.value;
        PlayerPrefs.SetFloat("bgmVolume", bgmVolumeSlider.value);
    }

    public void ChangeSfxVolume()
    {
        sfxVolume = sfxVolumeSlider.value;
        PlayerPrefs.SetFloat("sfxVolume", sfxVolumeSlider.value);
    }
}
