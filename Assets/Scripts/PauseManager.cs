using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public static bool isGameActive = true;
    private InputAction escape;
    // Pause Menu UI
    [SerializeField] protected GameObject pauseMenu;
    [SerializeField] protected GameObject settingsMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        escape = InputSystem.actions.FindAction("Escape");
        pauseMenu.SetActive(false);
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

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        isGameActive = false;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        isGameActive = true;
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
