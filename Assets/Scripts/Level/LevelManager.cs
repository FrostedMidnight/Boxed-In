using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelPlayerController player;
    [SerializeField] private LevelGoal goal;
    [SerializeField] private Transform boxesParent;
    [SerializeField] private int stepLimit;
    [SerializeField] private Grid grid;
    private bool levelWon = false;
    private int remainingSteps;
    public int RemainingSteps => remainingSteps;
    private BoxController[] boxes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        remainingSteps = stepLimit;
        boxes = boxesParent.GetComponentsInChildren<BoxController>(true);
    }

    void Update()
    {
        Vector3Int playerCell = grid.WorldToCell(player.transform.position);
        Vector3Int goalCell = grid.WorldToCell(goal.transform.position);

        if (!levelWon)
        {
            if (playerCell == goalCell)
            {
                levelWon = true;
                LevelUIManager.Instance.Wins();
            } else if (remainingSteps <= 0)
            {
                LevelUIManager.Instance.GameOver();
            }
        }
    }

    public void RestartLevel()
    {
        foreach (BoxController box in boxes)
        {
            box.Restart();
        }
        player.Restart();
        remainingSteps = stepLimit;
        levelWon = false;
    }

    public void DecrementStep(int stepNumber)
    {
        remainingSteps -= stepNumber;
    }
}
