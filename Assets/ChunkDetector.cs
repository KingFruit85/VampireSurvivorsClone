using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkDetector : MonoBehaviour
{
    GameObject Player;
    GameObject ChunkPrefab;
    public GameObject MyProbe;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        ChunkPrefab = Resources.Load<GameObject>("World/Chunk");
        MyProbe.GetComponent<ChunkProbe>().SetMyDetector(gameObject);
    }

    public float lookRadius = 8.5f;
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void Update()
    {
        if (Vector2.Distance(Player.transform.position, transform.position) <= lookRadius)
        {
            var isPotentialSpawnOccupied = MyProbe.GetComponent<ChunkProbe>().CheckIfOccupied();

            if (!isPotentialSpawnOccupied)
            {
                Vector2 spawnPosition = new Vector2();
                Transform chunkCenter = transform.parent.parent.transform;
                GameObject newChunk;

                switch (gameObject.name)
                {
                    case "North":
                        spawnPosition = new Vector2(chunkCenter.position.x, chunkCenter.position.y + 26f);
                        newChunk = Instantiate(ChunkPrefab, spawnPosition, Quaternion.identity) as GameObject;
                        newChunk.transform.Find("PlayerDetectors").transform.Find("South").gameObject.SetActive(false);
                        newChunk.transform.Find("PlayerDetectors").transform.Find("South Probe").gameObject.SetActive(false);
                        newChunk.transform.parent = GameObject.Find("WorldMap").transform;
                        break;
                    case "South":
                        spawnPosition = new Vector2(chunkCenter.position.x, chunkCenter.position.y - 26f);
                        newChunk = Instantiate(ChunkPrefab, spawnPosition, Quaternion.identity) as GameObject;
                        newChunk.transform.Find("PlayerDetectors").transform.Find("North").gameObject.SetActive(false);
                        newChunk.transform.Find("PlayerDetectors").transform.Find("North Probe").gameObject.SetActive(false);
                        newChunk.transform.parent = GameObject.Find("WorldMap").transform;
                        break;
                    case "East":
                        spawnPosition = new Vector2(chunkCenter.position.x + 26f, chunkCenter.position.y);
                        newChunk = Instantiate(ChunkPrefab, spawnPosition, Quaternion.identity) as GameObject;
                        newChunk.transform.Find("PlayerDetectors").transform.Find("West").gameObject.SetActive(false);
                        newChunk.transform.Find("PlayerDetectors").transform.Find("West Probe").gameObject.SetActive(false);
                        newChunk.transform.parent = GameObject.Find("WorldMap").transform;
                        break;
                    case "West":
                        spawnPosition = new Vector2(chunkCenter.position.x - 26f, chunkCenter.position.y);
                        newChunk = Instantiate(ChunkPrefab, spawnPosition, Quaternion.identity) as GameObject;
                        newChunk.transform.Find("PlayerDetectors").transform.Find("East").gameObject.SetActive(false);
                        newChunk.transform.Find("PlayerDetectors").transform.Find("East Probe").gameObject.SetActive(false);
                        newChunk.transform.parent = GameObject.Find("WorldMap").transform;
                        break;

                    case "NorthWest":
                        spawnPosition = new Vector2(chunkCenter.position.x - 26f, chunkCenter.position.y + 26f);
                        newChunk = Instantiate(ChunkPrefab, spawnPosition, Quaternion.identity) as GameObject;
                        newChunk.transform.Find("PlayerDetectors").transform.Find("SouthEast").gameObject.SetActive(false);
                        newChunk.transform.Find("PlayerDetectors").transform.Find("SouthEast Probe").gameObject.SetActive(false);
                        newChunk.transform.parent = GameObject.Find("WorldMap").transform;
                        break;

                    case "NorthEast":
                        spawnPosition = new Vector2(chunkCenter.position.x + 26f, chunkCenter.position.y + 26f);
                        newChunk = Instantiate(ChunkPrefab, spawnPosition, Quaternion.identity) as GameObject;
                        newChunk.transform.Find("PlayerDetectors").transform.Find("SouthWest").gameObject.SetActive(false);
                        newChunk.transform.Find("PlayerDetectors").transform.Find("SouthWest Probe").gameObject.SetActive(false);
                        newChunk.transform.parent = GameObject.Find("WorldMap").transform;
                        break;

                    case "SouthEast":
                        spawnPosition = new Vector2(chunkCenter.position.x + 26f, chunkCenter.position.y - 26f);
                        newChunk = Instantiate(ChunkPrefab, spawnPosition, Quaternion.identity) as GameObject;
                        newChunk.transform.Find("PlayerDetectors").transform.Find("NorthWest").gameObject.SetActive(false);
                        newChunk.transform.Find("PlayerDetectors").transform.Find("NorthWest Probe").gameObject.SetActive(false);
                        newChunk.transform.parent = GameObject.Find("WorldMap").transform;
                        break;

                    case "SouthWest":
                        spawnPosition = new Vector2(chunkCenter.position.x - 26f, chunkCenter.position.y - 26f);
                        newChunk = Instantiate(ChunkPrefab, spawnPosition, Quaternion.identity) as GameObject;
                        newChunk.transform.Find("PlayerDetectors").transform.Find("NorthWest").gameObject.SetActive(false);
                        newChunk.transform.Find("PlayerDetectors").transform.Find("NorthWest Probe").gameObject.SetActive(false);
                        newChunk.transform.parent = GameObject.Find("WorldMap").transform;
                        break;
                }

                MyProbe.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
