using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

using UnityEngine.SceneManagement;

public class LevelPlayerController : MonoBehaviour
{
    private bool isMoving = false;
    private Vector3Int currentCell;
    private Vector3Int initialPosition;
    private InputAction moveUp;
    private InputAction moveDown;
    private InputAction moveRight;
    private InputAction moveLeft;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Grid grid;
    [SerializeField] private Tilemap floor;
    [SerializeField] private Tilemap walls;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Sprite catInitialSprite;
    [SerializeField] private Sprite catUp;
    [SerializeField] private Sprite catDown;
    [SerializeField] private Sprite catLeft;
    [SerializeField] private Sprite catRight;

    // SFX
    private AudioSource playerAudioSource;
    [SerializeField] private AudioClip[] footstepSounds;
    [SerializeField] private AudioClip[] meows;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveUp = InputSystem.actions.FindAction("MoveUp");
        moveDown = InputSystem.actions.FindAction("MoveDown");
        moveRight = InputSystem.actions.FindAction("MoveRight");
        moveLeft = InputSystem.actions.FindAction("MoveLeft");

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = catInitialSprite;

        // Sets up initial position and step limit
        initialPosition = grid.WorldToCell(transform.position);
        currentCell = initialPosition;
        SnapToGrid();

        playerAudioSource = GetComponent<AudioSource>();
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
                    spriteRenderer.sprite = catUp;
                    direction = Vector3Int.up;
                }
                if (moveDown.WasPressedThisFrame())
                {
                    spriteRenderer.sprite = catDown;
                    direction = Vector3Int.down;
                }
                if (moveRight.WasPressedThisFrame())
                {
                    spriteRenderer.sprite = catRight;
                    direction = Vector3Int.right;
                }
                if (moveLeft.WasPressedThisFrame())
                {
                    spriteRenderer.sprite = catLeft;
                    direction = Vector3Int.left;
                }

                if (direction != Vector3Int.zero)
                {
                    Move(direction);
                    AudioClip footstepSound = footstepSounds[Random.Range(0,footstepSounds.Length)];
                    playerAudioSource.PlayOneShot(footstepSound, SoundManager.sfxVolume);

                    int willMeowInt = Random.Range(0,10);
                    if(willMeowInt < 1)
                    {
                        AudioClip meow = meows[Random.Range(0,meows.Length)];
                        playerAudioSource.PlayOneShot(meow, SoundManager.sfxVolume);
                    }
                }
            }
        }
    }

    private void Move(Vector3Int direction)
    {
        // Checks target cell availability and moves
        isMoving = true;
        int stepCost = 1;
        Vector3Int nextCell = currentCell + direction;

        if (floor != null && floor.HasTile(nextCell))
        {
            if (walls == null || !walls.HasTile(nextCell))
            {
                BoxController box = GetBoxAt(nextCell);
                if (box && box.IsMovable(direction))
                {
                    stepCost = box.MoveTo(direction);
                    currentCell = nextCell;
                    levelManager.DecrementStep(stepCost);
                    SnapToGrid();
                } else if (box == null)
                {
                    currentCell = nextCell;
                    levelManager.DecrementStep(stepCost);
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

    public void Restart()
    {
        spriteRenderer.sprite = catInitialSprite;
        currentCell = initialPosition;
        SnapToGrid();
    }
}
