using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldPauseManager : PauseManager
{
    public GameObject settingsMenu;

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void OpenSettings()
    {
        settingsMenu.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
    }

    public void CloseSettings()
    {
        settingsMenu.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(true);
    }
}
