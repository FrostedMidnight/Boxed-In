using UnityEngine;

using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    // public TextMeshProUGUI titleText;
    // public Button startGameButton;
    // public Button quitGameButton;

    public GameObject titleMenu;
    public GameObject settingsMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        PauseManager.isGameActive = true;
        SceneManager.LoadScene("Overworld");
    }

    public void OpenSettings()
    {
        settingsMenu.gameObject.SetActive(true);
        titleMenu.gameObject.SetActive(false);
    }

    public void CloseSettings()
    {
        settingsMenu.gameObject.SetActive(false);
        titleMenu.gameObject.SetActive(true);
    }
}
