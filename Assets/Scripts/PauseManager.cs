using UnityEngine;

using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public static bool isGameActive = true;

    public TextMeshProUGUI pauseHeaderText;
    public Button resumeButton;
    public Button returnToTitleButton;

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

    public void PauseGame()
    {
        pauseHeaderText.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(true);
        returnToTitleButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void ResumeGame()
    {
        pauseHeaderText.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        returnToTitleButton.gameObject.SetActive(false);
        isGameActive = true;
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
