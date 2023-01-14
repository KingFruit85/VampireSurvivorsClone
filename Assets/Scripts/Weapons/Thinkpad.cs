using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thinkpad : MonoBehaviour
{
    public GameObject Player;
    private Vector3 PositionOffset;
    public ThinkPadWeapon ThinkPadWeapon;
    public float RotationSpeed = 4;
    public float CircleRadius = 1;
    private float Angle;
    public int HitsDealt = 0;
    public int HitsMax = 5;
    public float Damage = 5;
    public static event Action<GameObject> HitLimitReached;


    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        AttackDamageIncrease.DamageIncrease += AttackDamageIncrease_OnDamageIncrease;
    }

    void OnDestory()
    {
        AttackDamageIncrease.DamageIncrease -= AttackDamageIncrease_OnDamageIncrease;
    }

    void AttackDamageIncrease_OnDamageIncrease(float increase)
    {
        increase = Damage * increase;
        Damage += increase;
    }

    private void LateUpdate()
    {
        PositionOffset.Set(
            Mathf.Cos(Angle) * CircleRadius,
            Mathf.Sin(Angle) * CircleRadius,
            0
        );
        transform.position = Player.transform.position + PositionOffset;
        Angle += Time.deltaTime * RotationSpeed;
    }

    void Update()
    {
        if (HitsDealt >= HitsMax)
        {
            HitLimitReached?.Invoke(gameObject);
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<EnemyHealth>(out var enemyHealth))
        {
            enemyHealth.TakeDamage(Damage);
            HitsDealt++;
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
