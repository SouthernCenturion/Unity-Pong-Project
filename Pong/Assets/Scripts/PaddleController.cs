using UnityEngine;
using Unity.Netcode;

public abstract class PaddleController : NetworkBehaviour, ICollidable
{
    protected Rigidbody2D rb;
    
    private float moveSpeed;

    private NetworkVariable<float> networkYPosition = new NetworkVariable<float>(0f);

    public void OnHit(Collision2D collision)
    {
        Debug.Log("A paddle has hit the ball");
    }
    
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    
    public void SetMoveSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnHit(collision);
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

        if (IsOwner)
        {
            networkYPosition.Value = transform.position.y;
        }
        else
        {
            Vector3 pos = transform.position;
            pos.y = networkYPosition.Value;
            transform.position = pos;
        }
    }
    
    protected abstract float GetInputAxis();
    
    protected void UpdateVelocity(float input)
    {
        rb.linearVelocity = new Vector2(0f, input * moveSpeed);
    }
}