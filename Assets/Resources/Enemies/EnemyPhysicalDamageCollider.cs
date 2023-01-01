using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPhysicalDamageCollider : MonoBehaviour
{
    public int AttackDamage;
    public float AttackCoolDown;
    float TimeOfLastAttack;
    public bool IsTouchingPlayer = false;
    public PlayerHealth PlayerHealth;

    void Start()
    {
        TimeOfLastAttack = Time.time;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsTouchingPlayer = true;
            PlayerHealth = other.transform.GetComponent<PlayerHealth>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsTouchingPlayer = false;
        }
    }

    void Update()
    {
        if (IsTouchingPlayer && Time.time >= (TimeOfLastAttack + AttackCoolDown))
        {
            PlayerHealth.TakeDamage(AttackDamage);
            TimeOfLastAttack = Time.time;
        }
    }
}
