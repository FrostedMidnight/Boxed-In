using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private bool isMoving = false;
    private Vector3Int currentCell;
    private InputAction moveUp;
    private InputAction moveDown;
    private InputAction moveRight;
    private InputAction moveLeft;
    [SerializeField] private Grid grid;
    [SerializeField] private Tilemap ground;
    [SerializeField] private Tilemap walls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveUp = InputSystem.actions.FindAction("MoveUp");
        moveDown = InputSystem.actions.FindAction("MoveDown");
        moveRight = InputSystem.actions.FindAction("MoveRight");
        moveLeft = InputSystem.actions.FindAction("MoveLeft");

        Debug.Log($"MoveUp found: {moveUp != null}");
        Debug.Log($"MoveDown found: {moveDown != null}");
        Debug.Log($"MoveRight found: {moveRight != null}");
        Debug.Log($"MoveLeft found: {moveLeft != null}");

        currentCell = grid.WorldToCell(transform.position);
        SnapToGrid();
    }

    // Update is called once per frame
    void Update()
    {
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

    private void Move(Vector3Int direction)
    {
        Debug.Log("moving");
        isMoving = true;
        Vector3Int nextCell = currentCell + direction;

        if (ground != null && ground.HasTile(nextCell))
        {
            if (walls == null || !walls.HasTile(nextCell))
            {
                Debug.Log("if-block executed");
                currentCell = nextCell;
                SnapToGrid();
            }
        }
        isMoving = false;
    }

    private void SnapToGrid()
    {
        transform.position = grid.GetCellCenterWorld(currentCell);
    }
}
