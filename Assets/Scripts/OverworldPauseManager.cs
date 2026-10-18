using UnityEngine;

using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class OverworldPauseManager : PauseManager
{
    // public static bool isGameActive = true;

    // public TextMeshProUGUI pauseHeaderText;
    // public Button resumeButton;
    // public Button returnToTitleButton;

    // public static bool isGameActive = true;

    // [SerializeField] private TextMeshProUGUI pauseHeaderText;
    // [SerializeField] private Button resumeButton;
    // [SerializeField] private Button returnToTitleButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isGameActive) PauseGame();
            else ResumeGame();
        }
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
