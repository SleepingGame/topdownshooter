using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstaclePrefab;

    public float spawnInterval = 2f;

    public float spawnWidth = 10f;
    public float spawnDepth = 10f;

    public float spawnHeight = 1f;


    public int maxObstacles = 5;

    public List<GameObject> obstacles = new List<GameObject>();

    
    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }
    IEnumerator SpawnObstacles()
    {
        while (obstacles.Count < maxObstacles)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnWidth / 2f, spawnWidth / 2f), spawnHeight, Random.Range(-spawnDepth / 2f, spawnDepth / 2f));
            GameObject newObstacle = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);

            obstacles.Add(newObstacle);
            Debug.Log("ADDED OBJECTTTTT");

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
