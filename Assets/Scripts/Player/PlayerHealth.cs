using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;

    public static event Action<int, int> OnHealthChange;
    public static event Action GameOver;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            //game over
            GameOver?.Invoke();
            SceneManager.LoadScene("Game");
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
