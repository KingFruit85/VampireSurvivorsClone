using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thinkpad : MonoBehaviour
{
    public Transform Target;

    public float RotationSpeed = 5;

    public float CircleRadius = 1;

    private Vector3 positionOffset;
    private float angle;

    private void LateUpdate()
    {
        positionOffset.Set(
            Mathf.Sin(angle) * CircleRadius,
            0, 0
        );
        transform.position = Target.position + positionOffset;
        angle += Time.deltaTime * RotationSpeed;
    }
}
