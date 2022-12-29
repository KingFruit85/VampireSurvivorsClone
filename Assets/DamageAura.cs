using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAura : MonoBehaviour
{
    [SerializeField]
    float TimeOfLastAttack;

    void Start()
    {
        TimeOfLastAttack = Time.time;
    }

    void Update()
    {

        if (Time.time >= (TimeOfLastAttack + 1.0f))
        {
            Collider2D[] HitEnemies = Physics2D.OverlapCircleAll(transform.position, 2.0f, LayerMask.GetMask("Enemy"));
            foreach (var collider in HitEnemies)
            {
                collider.transform.TryGetComponent(out Health health);
                health.TakeDamage(5);
            }
            TimeOfLastAttack = Time.time;
        }
    }
}
