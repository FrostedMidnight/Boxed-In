using UnityEngine;

using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class OverworldPauseManager : PauseManager
{
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
