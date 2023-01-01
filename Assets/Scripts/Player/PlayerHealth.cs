using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public static event Action<int, int> OnHealthChange;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        DamagePopup.Create(transform.position, damage, false);
        OnHealthChange?.Invoke(currentHealth, maxHealth);
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
        
        OnHealthChange?.Invoke(currentHealth, maxHealth);
    }
}
