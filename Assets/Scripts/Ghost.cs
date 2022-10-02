using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ghost : MonoBehaviour
{
/*    private Rigidbody2D rb;
    int xMoveDirection = 1;
    int yMoveDirection = -1;
    [SerializeField] float moveSpeed = 1f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        StartCoroutine(Walk());
    }

    IEnumerator Walk()
    {
        float walkInterval = Random.Range(1.0f, 3.0f);
        yield return new WaitForSeconds(walkInterval);
        xMoveDirection = Random.Range(-1, 1);
        yMoveDirection = Random.Range(-1, 1);
        Debug.Log(xMoveDirection);
        StartCoroutine(Walk());
    }*/

    private void Update()
    {
/*        rb.velocity = new Vector2(xMoveDirection * moveSpeed, yMoveDirection * rb.velocity.y);
        rb.velocity = new Vector2(xMoveDirection * moveSpeed, yMoveDirection * rb.velocity.y);*/
    }


}
