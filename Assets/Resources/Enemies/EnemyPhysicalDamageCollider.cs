using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPhysicalDamageCollider : MonoBehaviour
{
    public int AttackDamage;
    public float AttackCoolDown;
    public float TimeOfLastAttack;
    public bool IsTouchingPlayer = false;
    public PlayerHealth PlayerHealth;

    void Start()
    {
        TimeOfLastAttack = Time.timeSinceLevelLoad + 1f;
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
        if (IsTouchingPlayer && Time.timeSinceLevelLoad >= (TimeOfLastAttack + AttackCoolDown))
        {
            PlayerHealth.TakeDamage(AttackDamage);
            TimeOfLastAttack = Time.timeSinceLevelLoad;
        }
    }
}
