using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacless;

    [SerializeField] private int maxObjects = 5;
    [SerializeField] private float spawnHeight = 1f;
    [SerializeField] private float space = 1f;
    [SerializeField] private float objscale = 2f;

    [SerializeField] private LayerMask wallLayerMask; 

    private List<GameObject> obstacles = new List<GameObject>();

    private void Start()
    {
        SpawnObstacles();
    }

    private void SpawnObstacles()
    {
        for (int i = 0; i < maxObjects; i++)
        {
            GameObject obstaclePrefab = obstacless[Random.Range(0, obstacless.Count)];
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
            // start using debugs, maybe the raycast is false
            spawnPos = new Vector3(Random.Range(transform.position.x - transform.localScale.x / objscale, transform.position.x + transform.localScale.x / objscale), spawnHeight, Random.Range(transform.position.z - transform.localScale.z / objscale, transform.position.z + transform.localScale.z / objscale));
            RaycastHit hit;
            if (Physics.Raycast(spawnPos, Vector3.down, out hit, 100f, wallLayerMask))
            {
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
        }
        return spawnPos;
    }
}