using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(3f, 3f);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        rb.linearVelocity = new Vector2(-rb.linearVelocity.x, rb.linearVelocity.y);
    }
}