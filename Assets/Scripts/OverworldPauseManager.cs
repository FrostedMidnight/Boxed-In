using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldPauseManager : PauseManager
{
    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
