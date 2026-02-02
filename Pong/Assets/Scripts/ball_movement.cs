using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    private float speed;
    private Vector2 direction;
    
    public float GetSpeed()
    {
        return speed;
    }
    
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
        UpdateVelocity();
    }
    
    public Vector2 GetDirection()
    {
        return direction;
    }
    
    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized;
        UpdateVelocity();
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        speed = 3f;
        direction = new Vector2(1f, 1f).normalized;
        
        UpdateVelocity();
    }
    
    void FixedUpdate()
    {
        rb.linearVelocity = direction * speed;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PaddleController>() != null)
        {
            direction = new Vector2(-direction.x, direction.y);
        }
        else
        {
            direction = new Vector2(direction.x, -direction.y);
        }
    }
    
    private void UpdateVelocity()
    {
        if (rb != null)
        {
            rb.linearVelocity = direction * speed;
        }
    }
}