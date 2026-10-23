using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUIManager : PauseManager
{
    public static LevelUIManager Instance { get; private set; }
    private bool gameWon;
    private InputAction restart;
    // UI pages
    [SerializeField] private GameObject restartMenu;
    [SerializeField] private GameObject levelClearMenu;

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

        restartMenu.SetActive(false);
        levelClearMenu.SetActive(false);
        restart = InputSystem.actions.FindAction("Restart");
        gameWon = false;

        uiAudioSource = GetComponent<AudioSource>();
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

    public void ReturnToOverworld()
    {
        uiAudioSource.PlayOneShot(clickSound, SoundManager.sfxVolume);
        isGameActive = true;
        SceneManager.LoadScene("Overworld");
    }

    public void WantToRestart()
    {
        uiAudioSource.PlayOneShot(clickSound, SoundManager.sfxVolume);
        isGameActive = false;
        restartMenu.SetActive(true);
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
        string currentlevel = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentlevel);
    }

    public void Wins()
    {
        gameWon = true;
        levelClearMenu.SetActive(true);
    }
}
