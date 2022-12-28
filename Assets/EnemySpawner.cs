using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    Vector3 PositionToSpawnEnemy;
    Vector3 Offset;
    Vector2 PlayerPosition;
    public GameObject[] EnemyTypes;
    float TimeSinceLastEnemySpawn;

    void Start()
    {
        // Always start with a low number to give a fresh run a chance?
        SpawnPack(20);
    }

    void Update()
    {
        if ((TimeSinceLastEnemySpawn + 5.0f) <= Time.time)
        {
            SpawnPack(20);
        }
    }

    void SpawnPack(int numberToSpawn)
    {
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        PositionToSpawnEnemy = PlayerPosition + new Vector2(Random.Range(-3.0f, 3.9f), Random.Range(-5.0f, 5.9f));

        GameObject EnemyToSpawn = EnemyTypes[Random.Range(0, EnemyTypes.Length)];

        for (int i = 0; i <= numberToSpawn; i++)
        {
            Vector3 OffsetPositionToSpawnEnemy = PositionToSpawnEnemy + new Vector3(Random.Range(-1.0f, 1.9f), Random.Range(-1.0f, 1.9f));
            GameObject mob = Instantiate(EnemyToSpawn, OffsetPositionToSpawnEnemy, Quaternion.identity);
        }

        TimeSinceLastEnemySpawn = Time.time;
    }
}
