using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    int Hitpoints;

    void Start()
    {
        switch (transform.tag)
        {
            case "Crab": Hitpoints = 20; break;
            case "Ghost": Hitpoints = 5; break;
            case "Skully": Hitpoints = 15; break;
            case "Worm": Hitpoints = 10; break;
            case "Player": Hitpoints = 100; break;
        }
    }

    public void TakeDamage(int damage)
    {
        Hitpoints = Hitpoints - damage;
        DamagePopup.Create(transform.position, damage, false);
    }

    void Update()
    {
        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
            // Drop XP pickup
            GameObject xp = Instantiate(Resources.Load<GameObject>("XpPickup"), transform.position, Quaternion.identity);
        }
    }

}
