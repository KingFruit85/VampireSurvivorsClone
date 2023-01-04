using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public static event Action MonsterDeath;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {

            if ((UnityEngine.Random.Range(0, 3) == 2))
            {
                GameObject xp = Instantiate(Resources.Load<GameObject>("XpPickup"), transform.position, Quaternion.identity);

            }
            MonsterDeath?.Invoke();
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        DamagePopup.Create(transform.position, damage, false);
    }

    public void Heal(int amountToHeal)
    {
        if (currentHealth + amountToHeal >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amountToHeal;
        }
    }

}
