using UnityEngine;

using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private GameObject titleMenu;
    [SerializeField] private GameObject settingsMenu;
    private AudioSource uiAudioSource;
    [SerializeField] private AudioClip clickSound;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        PauseManager.isGameActive = true;
        uiAudioSource.PlayOneShot(clickSound, SoundManager.sfxVolume);
        SceneManager.LoadScene("Overworld");
    }

    public void OpenSettings()
    {
        settingsMenu.gameObject.SetActive(true);
        titleMenu.gameObject.SetActive(false);
        uiAudioSource.PlayOneShot(clickSound, SoundManager.sfxVolume);
    }

    public void CloseSettings()
    {
        settingsMenu.gameObject.SetActive(false);
        titleMenu.gameObject.SetActive(true);
        uiAudioSource.PlayOneShot(clickSound, SoundManager.sfxVolume);
    }
}
