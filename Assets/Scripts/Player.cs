using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int currentStage = 0;
    public int currentHealth = 6;
    private bool highHealth = true;
    private bool isDead = false;
    [SerializeField] float moveSpeed = 1f;
    public bool SpecialEffecting = false;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private InGameUI inGameUI;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inGameUI = FindObjectOfType<InGameUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentHealth);
        BecomeDead();
        if (currentHealth <= 6 && highHealth)
        {
            highHealth = false;
            inGameUI.LowHealthing();
        }
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
        moveSpeed = moveSpeed + 2f;
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
