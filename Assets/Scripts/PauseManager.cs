using UnityEngine;

using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public static bool isGameActive = true;

    // Pause Menu UI
    [SerializeField] private TextMeshProUGUI pauseHeaderText;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button returnButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        pauseHeaderText.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(true);
        returnButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void ResumeGame()
    {
        pauseHeaderText.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);
        isGameActive = true;
    }
}
