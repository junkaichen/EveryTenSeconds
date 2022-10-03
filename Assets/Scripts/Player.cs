using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentHealthtext;
    public int currentStage = 0;
    public int currentHealth = 6;
    private bool highHealth = true;
    private bool isDead = false;
    [SerializeField] float moveSpeed = 1f;
    public bool SpecialEffecting = false;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private InGameUI inGameUI;
    private Animator animator;
    Vector2 playerVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inGameUI = FindObjectOfType<InGameUI>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthtext.text = "Health: " + currentHealth;
        /*        if (moveInput != Vector2.zero)
                {s
                    animator.SetBool("isMoving", false);
                }*/
        BecomeDead();
        if (currentHealth <= 6 && highHealth)
        {
            highHealth = false;
            inGameUI.LowHealthing();
        }
        if (moveInput != Vector2.zero)
        {
            playerVelocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
            rb.velocity = playerVelocity;
            animator.SetBool("isMoving", true);
        }
        else
        {
            playerVelocity = new Vector2(0f, 0f);
            rb.velocity = playerVelocity;
            animator.SetBool("isMoving", false);
        }
    }

    void FixedUpdate()
    {

     /*   rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);*/
    }

    void OnMove(InputValue value)
    {
      /*  animator.SetBool("isMoving", true);*/
        moveInput = value.Get<Vector2>();
        if (moveInput != Vector2.zero)
        {
            animator.SetFloat("horizontalMovement", moveInput.x);
            animator.SetFloat("verticalMovement", moveInput.y);
        }
 
        
    }

    public void SpeedUp()
    {
        moveSpeed = moveSpeed + 1.5f;
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
