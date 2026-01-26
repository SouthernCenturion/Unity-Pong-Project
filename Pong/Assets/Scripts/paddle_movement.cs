using UnityEngine;
public class PaddleMovement : MonoBehaviour
{
    public float speed = 5f;
    public KeyCode upKey = KeyCode.UpArrow;
    public KeyCode downKey = KeyCode.DownArrow;
    
    void Update()
    {
        float movement = 0f;
        
        if (Input.GetKey(upKey))
            movement = 1f;
        else if (Input.GetKey(downKey))
            movement = -1f;
        
        Vector3 newPosition = transform.position;
        newPosition.y += movement * speed * Time.deltaTime;
        transform.position = newPosition;
    }
}