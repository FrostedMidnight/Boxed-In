using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 7f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseManager.isGameActive)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            
            Vector2 movement = new Vector2(moveX, moveY);
            transform.Translate(movement * moveSpeed * Time.deltaTime);
        }
    }
}
