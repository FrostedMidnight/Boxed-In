using UnityEngine;
using TMPro;

public class StepsUI : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private TMP_Text stepsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stepsText.text = $"Steps left: {levelManager.RemainingSteps}";
    }
}
