using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/*using UnityEngine.UIElements;*/
using UnityEngine.UI;
public class Patrol : MonoBehaviour
{
    public GameObject myWayPoint;
    private Transform[] _waypoints = new Transform[4];
    private int _currentWaypointIndex = 0;
    private float moveSpeed = 3.2f;
    private Rigidbody2D myrigidbody2D;
    private bool huntering = false;
    private bool shocking = false;
    private Player myPlayer;
    private InGameUI inGameUI;
    private SpecialArea specialArea;
    private Animator animator;
    private AudioSource audioSource;
    private void Awake()
    {
        SpawnWayPoints();
        myrigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();


    }

    private void Start()
    {
        myPlayer = FindObjectOfType<Player>();
        inGameUI = FindObjectOfType<InGameUI>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        Vector3 myDirection = myPlayer.transform.position - transform.position;
        if (Mathf.Abs(myDirection.y) > Mathf.Abs(myDirection.x))
        {
            animator.SetFloat("verticalMovement", 1f);
        }
        else
        {
            if (myDirection.x > 0)
            {
                    animator.SetFloat("horizontalMovement", 1f);
            }
            else
            {
                animator.SetFloat("horizontalMovement", -1f);


            }
        }

       
        if (myPlayer.SpecialEffecting)
        {
            moveSpeed = 2;
        }
        /*        else if (shocking)
                {
                    moveSpeed = 0;
                }*/
        else
        {
            moveSpeed = 3.2f;
        }

        checkRange();
        if (!shocking)
        {
            if (huntering)
            {
                /*           transform.up = myPlayer.transform.position.normalized;*/
                transform.position = Vector2.MoveTowards(transform.position, myPlayer.transform.position, moveSpeed * Time.deltaTime);
            }
            else
            {
                Transform wp = _waypoints[_currentWaypointIndex].transform;
                if (Vector2.Distance(transform.position, wp.position) < 0.1f)
                {

                    _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
                }
                else
                {
                    /*myrigidbody2D.velocity = (wp.position - transform.position).normalized * moveSpeed;*/
                    /*      transform.up = wp.position.normalized;*/
                    transform.position = Vector2.MoveTowards(transform.position, wp.position, moveSpeed * Time.deltaTime);
                    /*transform.LookAt(wp.position);*/
                }

            }
        }


    }

    private void SpawnWayPoints()
    {
        for (int i = 0; i < 4; i++)
        {

            Vector2 position = Vector2.zero;
            position.x = Mathf.Round(Random.Range(-17, 17));
            position.y = Mathf.Round(Random.Range(-12, 12));
            _waypoints[i] = Instantiate(myWayPoint, position, Quaternion.identity).transform;
        }
    }

    private void checkRange()
    {
        if (Vector2.Distance(transform.position, myPlayer.transform.position) < 5f)
        {
            huntering = true;
        }
        else
        {
            huntering = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            myPlayer.currentHealth -= 4;
         
            shocking = true;
            StartCoroutine(ExitShocking());
            inGameUI.Damaged();
            audioSource.Play();
            if (myPlayer.IsDead())
            {
                Destroy(myPlayer.gameObject);
            }
        }
    }

    IEnumerator ExitShocking()
    {
        yield return new WaitForSeconds(2f);
        shocking = false;
    }








}
