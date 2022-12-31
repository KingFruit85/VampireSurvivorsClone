using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAura : MonoBehaviour
{
    [SerializeField]
    float TimeOfLastAttack;
    public int damage = 5;

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
                enemyHealth.TakeDamage(damage);
            }
            TimeOfLastAttack = Time.time;
        }
    }
}
