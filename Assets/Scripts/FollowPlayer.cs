using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Vector3 PlayerPosition;
    private Camera Camera;

    void Start()
    {
        Camera = GetComponent<Camera>();
    }

    void Update()
    {
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        Camera.transform.position = PlayerPosition;
    }
}
