using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelPlayerController player;
    [SerializeField] private Transform boxesParent;
    [SerializeField] private int stepLimit;
    private int remainingSteps;
    public int RemainingSteps => remainingSteps;
    private BoxController[] boxes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        remainingSteps = stepLimit;
        boxes = boxesParent.GetComponentsInChildren<BoxController>(true);
    }

    public void RestartLevel()
    {
        foreach (BoxController box in boxes)
        {
            box.Restart();
        }
        player.Restart();
        remainingSteps = stepLimit;
    }

    public void DecrementStep(int stepNumber)
    {
        remainingSteps -= stepNumber;
    }
}
