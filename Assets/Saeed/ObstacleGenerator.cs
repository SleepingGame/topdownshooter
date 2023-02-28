using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
   private List<GameObject> obstaclePrefabs;

   private int maxObjects = 5;
   private float spawnHeight = 1f;
   private float space = 1f;

    private List<GameObject> obstacles = new List<GameObject>();

    private void Start()
    {
        SpawnObstacles();
    }

    private void SpawnObstacles()
    {
        for (int i = 0; i < maxObjects; i++)
        {
            
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];
            Vector3 spawnPos = GetRandomSpawnPosition();
            GameObject newObstacle = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);

            obstacles.Add(newObstacle);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPos = Vector3.zero;

        bool Emptyplace = false;
        while (!Emptyplace)
        {
           
            spawnPos = new Vector3(Random.Range(transform.position.x - transform.localScale.x / 2f, transform.position.x + transform.localScale.x / 2f),  spawnHeight,Random.Range(transform.position.z - transform.localScale.z / 2f, transform.position.z + transform.localScale.z / 2f));
            Emptyplace = true;
            foreach (GameObject obstacle in obstacles)
            {
                if (Vector3.Distance(spawnPos, obstacle.transform.position) < space)
                {
                    Emptyplace = false;
                    break;
                }
            }
        }

        return spawnPos;
    }
}
