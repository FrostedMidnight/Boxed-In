using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUIManager : PauseManager
{
    public static LevelUIManager Instance { get; private set; }
    private InputAction restart;
    // UI pages
    [SerializeField] private GameObject restartMenu;
    [SerializeField] private GameObject gamePlayUI;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private DialogueTrigger levelStartDialogue;
    [SerializeField] private DialogueTrigger winDialogueTrigger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        // Singleton instance
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        gamePlayUI.SetActive(true);
        restartMenu.SetActive(false);
        restart = InputSystem.actions.FindAction("Restart");
        uiAudioSource = GetComponent<AudioSource>();

        levelStartDialogue.TriggerDialogue();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if(restart.WasPressedThisFrame() && isGameActive)
        {
            WantToRestart();
        }
    }

    private void RestartUI()
    {
        gamePlayUI.SetActive(true);
        restartMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        ClosePauseMenu();
    }

    public void ReturnToOverworld()
    {
        uiAudioSource.PlayOneShot(clickSound, SoundManager.sfxVolume);
        isGameActive = true;
        SceneManager.LoadScene("Overworld");
    }

    public void ReturnToTitle()
    {
        uiAudioSource.PlayOneShot(clickSound, SoundManager.sfxVolume);
        isGameActive = true;
        SceneManager.LoadScene("Title");
    }

    public void WantToRestart()
    {
        uiAudioSource.PlayOneShot(clickSound, SoundManager.sfxVolume);
        isGameActive = false;
        restartMenu.SetActive(true);
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverMenu.SetActive(true);
    }

    public void NoRestart()
    {
        uiAudioSource.PlayOneShot(clickSound, SoundManager.sfxVolume);
        isGameActive = true;
        restartMenu.SetActive(false);
    }

    public void YesRestart()
    {
        uiAudioSource.PlayOneShot(clickSound, SoundManager.sfxVolume);
        isGameActive = true;
        RestartUI();
        levelManager.RestartLevel();
    }

    public void Wins()
    {
        winDialogueTrigger.TriggerDialogue();
        // Somehow go to overworld AFTER this dialogue finishes
    }
}
