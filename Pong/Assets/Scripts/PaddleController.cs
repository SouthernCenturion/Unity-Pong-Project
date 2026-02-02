using UnityEngine;

public class PaddleController : MonoBehaviour
{
    protected Rigidbody2D rb;
    
    private float moveSpeed;
    
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    
    public void SetMoveSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }
    
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
    }
    
    void FixedUpdate()
    {
        float inputAxis = GetInputAxis();
        
        UpdateVelocity(inputAxis);
    }
    
    protected virtual float GetInputAxis()
    {
        return 0f;
    }
    
    protected void UpdateVelocity(float input)
    {
        rb.linearVelocity = new Vector2(0f, input * moveSpeed);
    }
    
}