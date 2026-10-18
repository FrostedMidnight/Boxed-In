using UnityEngine;

using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LevelPauseManager : PauseManager
{
    // Restart UI
    [SerializeField] private TextMeshProUGUI wantToRestartHeaderText;
    [SerializeField] private Button restartNoButton;
    [SerializeField] private Button restartYesButton;

    // Level Clear Text
    [SerializeField] private TextMeshProUGUI levelClearHeaderText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGameActive) PauseGame();
            else ResumeGame();
        }

        if(Input.GetKeyDown(KeyCode.R) && isGameActive)
        {
            WantToRestart();
        }
    }

    public void ReturnToOverworld()
    {
        isGameActive = true;
        SceneManager.LoadScene("Overworld");
    }

    public void WantToRestart()
    {
        isGameActive = false;
        wantToRestartHeaderText.gameObject.SetActive(true);
        restartNoButton.gameObject.SetActive(true);
        restartYesButton.gameObject.SetActive(true);
    }

    public void NoRestart()
    {
        isGameActive = true;
        wantToRestartHeaderText.gameObject.SetActive(false);
        restartNoButton.gameObject.SetActive(false);
        restartYesButton.gameObject.SetActive(false);
    }

    public void YesRestart()
    {
        isGameActive = true;
        string currentlevel = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentlevel);
    }
}
