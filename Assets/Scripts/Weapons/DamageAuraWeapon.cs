using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAuraWeapon : MonoBehaviour, IAbility
{
    float TimeOfLastAttack;
    public float Damage = 2;
    public Sprite Icon;
    public float AuraRadius = 2.0f;
    public const string AbilityName = "Damage Aura";

    public int CurrentAbilityLevel = 1;
    const string LevelOneDescription = "A damaging aura surrounding the player";
    const string LevelTwoDescription = "The aura's damage is slightly increased";
    const string LevelThreeDescription = "The aura's radius is slightly increased";

    void Start()
    {
        TimeOfLastAttack = Time.time;
        AttackDamageIncrease.DamageIncrease += AttackDamageIncrease_OnDamageIncrease;
    }

    void OnDestroy()
    {
        AttackDamageIncrease.DamageIncrease -= AttackDamageIncrease_OnDamageIncrease;
    }


    void AttackDamageIncrease_OnDamageIncrease(float increase)
    {
        increase = Damage * increase;
        Damage += increase;
    }

    void Update()
    {

        if (Time.time >= (TimeOfLastAttack + 1.0f))
        {
            Collider2D[] hitEnemies =
            Physics2D.OverlapCircleAll(
                transform.position,
                AuraRadius,
                LayerMask.GetMask("Enemy"));

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

    public string GetAbilityDescription(int level)
    {
        string description = string.Empty;

        switch (level)
        {
            case 1: description = LevelOneDescription; break;
            case 2: description = LevelTwoDescription; break;
            case 3: description = LevelThreeDescription; break;
        }

        return description;
    }

    public Sprite GetAbilityIcon()
    {
        return Icon;
    }

    public void LevelUpAbility()
    {
        CurrentAbilityLevel++;

        switch (CurrentAbilityLevel)
        {
            case 1:
                break;

            case 2:
                Damage += 2;
                break;

            case 3:
                AuraRadius += 1f;
                break;
        }
    }

    public int GetAbilityLevel()
    {
        return CurrentAbilityLevel;
    }
}
