using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public static bool isGameActive = true;
    protected InputAction escape;
    // Pause Menu UI
    [SerializeField] protected GameObject pauseMenu;
    [SerializeField] protected GameObject settingsMenu;

    protected AudioSource uiAudioSource;
    [SerializeField] protected AudioClip clickSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        isGameActive = true;
        escape = InputSystem.actions.FindAction("Escape");
        pauseMenu.SetActive(false);

        uiAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (escape.WasPressedThisFrame())
        {
            Debug.Log("escape pressed");
            if (isGameActive)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    protected void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        isGameActive = false;
        uiAudioSource.PlayOneShot(clickSound, SoundManager.sfxVolume);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        isGameActive = true;
        uiAudioSource.PlayOneShot(clickSound, SoundManager.sfxVolume);
    }

    public void OpenSettings()
    {
        settingsMenu.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
        uiAudioSource.PlayOneShot(clickSound, SoundManager.sfxVolume);
    }

    public void CloseSettings()
    {
        settingsMenu.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(true);
        uiAudioSource.PlayOneShot(clickSound, SoundManager.sfxVolume);
    }
}
