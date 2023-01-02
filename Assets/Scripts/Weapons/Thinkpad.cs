using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thinkpad : MonoBehaviour, IAbility
{
    public Transform Target;

    public float RotationSpeed = 7;

    public float CircleRadius = 1;

    public float ElevationOffset = 0;

    private Vector3 positionOffset;
    private float angle;
    public int Damage = 5;
    public Sprite Icon;
    public const string AbilityName = "ThinkPad";
    public const string Description = "Circles around the player damaging enemies that touch it";

    void Awake()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

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
        if (other.gameObject.TryGetComponent<EnemyHealth>(out var enemyHealth))
        {
            enemyHealth.TakeDamage(Damage);
        }
    }

    public string GetAbilityName()
    {
        return AbilityName;
    }

    public string GetAbilityDescription()
    {
        return Description;
    }

    public Sprite GetAbilityIcon()
    {
        return Icon;
    }

    public int GetAbilityDamage()
    {
        return Damage;
    }
}
