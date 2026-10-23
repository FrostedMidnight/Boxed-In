using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class OverworldPauseManager : PauseManager
{
    // protected override void Start()
    // {
    //     escape = InputSystem.actions.FindAction("Escape");
    //     pauseMenu.SetActive(false);
    // }

    public void ReturnToTitle()
    {
        uiAudioSource.PlayOneShot(clickSound, SoundManager.sfxVolume);
        SceneManager.LoadScene("Title");
    }
}
