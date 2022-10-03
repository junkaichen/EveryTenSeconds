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
    private float moveSpeed = 2f;
    private Rigidbody2D myrigidbody2D;
    private bool huntering = false;
    private Player myPlayer;
    private InGameUI inGameUI;
    private SpecialArea specialArea;
    private void Awake()
    {
        SpawnWayPoints();
        myrigidbody2D = GetComponent<Rigidbody2D>();
        

    }

    private void Start()
    {
        myPlayer = FindObjectOfType<Player>();
        inGameUI = FindObjectOfType<InGameUI>();
    }

    private void Update()
    {
        specialArea = FindObjectOfType<SpecialArea>();
        if (specialArea)
        {
            moveSpeed = 3.5f;
        }
        else
        {
            moveSpeed = 2;
        }
            checkRange();
        if (huntering)
        {
            transform.up = myPlayer.transform.position.normalized;
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
                transform.up = wp.position.normalized;
                transform.position = Vector2.MoveTowards(transform.position, wp.position, moveSpeed * Time.deltaTime);
                /*transform.LookAt(wp.position);*/
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
            Debug.Log(myPlayer.currentHealth);
            myPlayer.currentHealth -= 3;
            inGameUI.Damaged();
            if (myPlayer.IsDead())
            {
                Destroy(myPlayer.gameObject);
            }
        }
    }







}
