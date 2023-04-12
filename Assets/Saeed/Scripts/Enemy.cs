using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject[] spawnPoints;
    public float spawnDelay = 2f;
    public float shootingRange = 10f;
    public float speed = 5f;
    public GameObject enemyPrefab;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            GameObject enemyInstance = Instantiate(enemyPrefab, spawnPoints[spawnIndex].transform.position, Quaternion.identity);
            enemyInstance.GetComponent<EnemyController>().SetTarget(player);
        }
    }
}