using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thinkpad : MonoBehaviour
{
    public Vector3 Target;
    private Vector3 positionOffset;
    public float RotationSpeed = 4;
    public float CircleRadius = 1;
    private float angle;
    public float Damage = 5;

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform.position;
        AttackDamageIncrease.DamageIncrease += AttackDamageIncrease_OnDamageIncrease;
    }

    void OnDestory()
    {
        AttackDamageIncrease.DamageIncrease -= AttackDamageIncrease_OnDamageIncrease;
    }

    void AttackDamageIncrease_OnDamageIncrease(float increase)
    {
        Debug.Log($"Increasing damage for {gameObject.name}");
        increase = Damage * increase;
        Damage += increase;
    }

    private void LateUpdate()
    {
        positionOffset.Set(
            Mathf.Cos(angle) * CircleRadius,
            Mathf.Sin(angle) * CircleRadius,
            0
        );
        transform.position = Target + positionOffset;
        angle += Time.deltaTime * RotationSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<EnemyHealth>(out var enemyHealth))
        {
            enemyHealth.TakeDamage(Damage);
        }
    }

    public void AddSpeed(float speed)
    {
        RotationSpeed += speed;
    }

    public void AddRadius(float radius)
    {
        CircleRadius += radius;
    }
}
