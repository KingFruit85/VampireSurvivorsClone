using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAura : MonoBehaviour, IAbility
{
    float TimeOfLastAttack;
    public int Damage = 5;
    public Sprite Icon;
    public const string AbilityName = "Damage Aura";
    public const string Description = "A damaging aura surrounding the player";

    void Start()
    {
        TimeOfLastAttack = Time.time;
    }

    void Update()
    {

        if (Time.time >= (TimeOfLastAttack + 1.0f))
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 2.0f, LayerMask.GetMask("Enemy"));
            foreach (var collider in hitEnemies)
            {
                collider.transform.TryGetComponent<EnemyHealth>(out var enemyHealth);
                enemyHealth.TakeDamage(Damage);
            }
            TimeOfLastAttack = Time.time;
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
