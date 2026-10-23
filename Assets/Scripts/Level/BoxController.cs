using UnityEngine;
using UnityEngine.Tilemaps;

public class BoxController : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private Tilemap floor;
    [SerializeField] private Tilemap walls;
    private Vector3Int currentCell;
    public Vector3Int CurrentCell => currentCell;
    private Vector3Int nextCell;
    private Vector3Int initialPosition;

    private AudioSource boxAudioSource;
    [SerializeField] private AudioClip boxMoveSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPosition = grid.WorldToCell(transform.position);
        currentCell = initialPosition;
        SnapToGrid();

        boxAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SnapToGrid()
    {
        transform.position = grid.GetCellCenterWorld(currentCell);
    }

    public int MoveTo(Vector3Int direction)
    {
        int costToMove = 2;
        nextCell = currentCell + direction;
        BoxController box = GetBoxAt(nextCell);
        if (box != null)
        {
            costToMove += box.MoveTo(direction);
        }

        currentCell = nextCell;
        SnapToGrid();

        boxAudioSource.PlayOneShot(boxMoveSound, SoundManager.sfxVolume);
        return costToMove;
    }

    public bool IsMovable(Vector3Int direction)
    {
        nextCell = currentCell + direction;
        BoxController box = GetBoxAt(nextCell);

        if (floor != null && floor.HasTile(nextCell))
        {
            if (walls == null || !walls.HasTile(nextCell))
            {
                if (box == null)
                {
                    return true;
                }
                return box.IsMovable(direction);
            }
        }
        return false;
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

    public void Restart()
    {
        currentCell = initialPosition;
        SnapToGrid();
    }
}
