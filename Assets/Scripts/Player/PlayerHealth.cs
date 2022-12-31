using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public static event Action<int> OnHealthChange;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            //game over
            gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        DamagePopup.Create(transform.position, damage, false);
        if (OnHealthChange != null) 
        {
            OnHealthChange(currentHealth);
        }
    }

    public void Heal(int amountToHeal)
    {
        if (currentHealth + amountToHeal >= maxHealth) {
            currentHealth = maxHealth;
        } else {
            currentHealth += amountToHeal;
        }
        
        if (OnHealthChange != null) 
        {
            OnHealthChange(currentHealth);
        }
    }
}
