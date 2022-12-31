using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    Vector3 PositionToSpawnEnemy;
    Vector2 PlayerPosition;
    public GameObject[] EnemyTypes;
    float TimeSinceLastEnemySpawn;

    void Start()
    {
        SpawnPack();
    }

    void Update()
    {
        if ((TimeSinceLastEnemySpawn + 5.0f) <= Time.time)
        {
            SpawnPack();
        }
    }

    void SpawnPack()
    {
        int NumberOfMobsToSpawn = Random.Range(5, 26);
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        PositionToSpawnEnemy = PlayerPosition + new Vector2(Random.Range(-15.9f, 15.9f), Random.Range(-15.9f, 15.9f));

        GameObject EnemyToSpawn = EnemyTypes[Random.Range(0, EnemyTypes.Length)];

        for (int i = 0; i <= NumberOfMobsToSpawn; i++)
        {
            Vector3 OffsetPositionToSpawnEnemy = PositionToSpawnEnemy + new Vector3(Random.Range(-2.0f, 2.9f), Random.Range(-2.0f, 2.9f));
            GameObject mob = Instantiate(EnemyToSpawn, OffsetPositionToSpawnEnemy, Quaternion.identity);
        }

        TimeSinceLastEnemySpawn = Time.time;
    }
}
