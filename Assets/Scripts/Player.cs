using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int currentStage = 0;
    public int currentHealth = 6;
    private bool isDead = false;
    [SerializeField] float moveSpeed = 1f;
    
    private Vector2 moveInput;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        BecomeDead();
    }

    void FixedUpdate()
    {
        
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void SpeedUp()
    {
        moveSpeed = moveSpeed + 1f;
    }

    public void BecomeDead()
    {
        if (currentHealth <= 0)
        {
            isDead = true;
        }
    }

    public bool IsDead()
    {
        return isDead;
    }


}
