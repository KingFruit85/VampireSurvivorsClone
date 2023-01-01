using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 PlayerPosition;
    float Speed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = Vector3.MoveTowards(transform.position, PlayerPosition, Speed * Time.deltaTime);
    }

}
