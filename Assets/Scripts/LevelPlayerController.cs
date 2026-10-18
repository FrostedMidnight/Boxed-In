using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private int levelStepLimit;
    private int stepsLeft;
    public int StepsLeft => stepsLeft;
    private bool isMoving = false;
    private Vector3Int currentCell;
    private Vector3Int initialPosition;
    private InputAction moveUp;
    private InputAction moveDown;
    private InputAction moveRight;
    private InputAction moveLeft;
    [SerializeField] private Grid grid;
    [SerializeField] private Tilemap floor;
    [SerializeField] private Tilemap walls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveUp = InputSystem.actions.FindAction("MoveUp");
        moveDown = InputSystem.actions.FindAction("MoveDown");
        moveRight = InputSystem.actions.FindAction("MoveRight");
        moveLeft = InputSystem.actions.FindAction("MoveLeft");

        // Sets up initial position and step limit
        initialPosition = grid.WorldToCell(transform.position);
        currentCell = initialPosition;
        stepsLeft = levelStepLimit;
        SnapToGrid();
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseManager.isGameActive)
        {
            // Controls grid movement
            if (isMoving == false)
            {
                Vector3Int direction = Vector3Int.zero;

                if (moveUp.WasPressedThisFrame())
                {
                    Debug.Log("UP PRESSED");
                    direction = Vector3Int.up;
                }
                if (moveDown.WasPressedThisFrame())
                {
                    direction = Vector3Int.down;
                }
                if (moveRight.WasPressedThisFrame())
                {
                    direction = Vector3Int.right;
                }
                if (moveLeft.WasPressedThisFrame())
                {
                    direction = Vector3Int.left;
                }

                if (direction != Vector3Int.zero)
                {
                    Move(direction);
                }
            }
        }
    }

    private void Move(Vector3Int direction)
    {
        // Checks target cell availability and moves
        isMoving = true;
        Vector3Int nextCell = currentCell + direction;

        if (floor != null && floor.HasTile(nextCell))
        {
            if (walls == null || !walls.HasTile(nextCell))
            {
                BoxController box = GetBoxAt(nextCell);
                if (box && box.IsMovable(direction))
                {
                    box.MoveTo(direction);
                    currentCell = nextCell;
                    stepsLeft -= 1;
                    SnapToGrid();
                } else if (box == null)
                {
                    currentCell = nextCell;
                    stepsLeft -= 1;
                    SnapToGrid();
                }
            }
        }
        isMoving = false;
    }

    private BoxController GetBoxAt(Vector3Int cell)
    {
        foreach (BoxController box in FindObjectsByType<BoxController>(FindObjectsSortMode.None))
        {
            if (box.CurrentCell == cell)
                return box;
        }

        return null;
    }

    private void SnapToGrid()
    {
        transform.position = grid.GetCellCenterWorld(currentCell);
    }
}
