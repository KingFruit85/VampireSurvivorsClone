using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thinkpad : MonoBehaviour
{
    public Transform Target;

    public float RotationSpeed = 5;

    public float CircleRadius = 1;

    public float ElevationOffset = 0;

    private Vector3 positionOffset;
    private float angle;

    private void LateUpdate()
    {
        positionOffset.Set(
            Mathf.Cos(angle) * CircleRadius,
            Mathf.Sin(angle) * CircleRadius,
            ElevationOffset
        );
        transform.position = Target.position + positionOffset;
        angle += Time.deltaTime * RotationSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            other.transform.TryGetComponent(out Health health);
            health.TakeDamage(5);
        }
    }
}
