using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        // switch (transform.tag)
        // {
        //     case "Crab": Hitpoints = 20; break;
        //     case "Ghost": Hitpoints = 5; break;
        //     case "Skully": Hitpoints = 15; break;
        //     case "Worm": Hitpoints = 10; break;
        //     case "Player": Hitpoints = 100; break;
        // }
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            GameObject xp = Instantiate(Resources.Load<GameObject>("XpPickup"), transform.position, Quaternion.identity);
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
        if (currentHealth + amountToHeal >= maxHealth) {
            currentHealth = maxHealth;
        } else {
            currentHealth += amountToHeal;
        }
    }

}
