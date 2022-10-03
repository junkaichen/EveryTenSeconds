using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    private BoxCollider2D spawnArea;
    [SerializeField] SpecialArea specialArea;
    [SerializeField] Ghost ghost;
    [SerializeField] int ghostAmount = 1;

    void Awake()
    {
        spawnArea = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        StartCoroutine(SpawnItems());
    }


    IEnumerator SpawnItems()
    {
        SpawnSpecialArea();
        SpawnGhost();
        yield return new WaitForSeconds(10);
        StartCoroutine(SpawnItems());


    }

    private void SpawnSpecialArea()
    {
        Bounds bounds = spawnArea.bounds;
        Vector2 position = Vector2.zero;
        position.x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
        position.y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));
        Instantiate(specialArea, position, Quaternion.identity);
    }
    private void SpawnGhost()
    {
        Bounds bounds = spawnArea.bounds;
        Vector2 position = Vector2.zero;
        position.x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
        position.y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));
        Instantiate(ghost, position, Quaternion.identity);
    }
}
