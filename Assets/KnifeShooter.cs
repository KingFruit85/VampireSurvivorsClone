using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeShooter : MonoBehaviour
{
    public GameObject Knife;
    public GameObject Player;
    float TimeOfLastAttack;
    public float AttackDelay;

    public
    void Start()
    {
        Instantiate(Knife, Player.transform.position, Quaternion.identity);
        TimeOfLastAttack = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= (TimeOfLastAttack + AttackDelay))
        {
            Instantiate(Knife, Player.transform.position, Quaternion.identity);
            TimeOfLastAttack = Time.time;
        }
    }
}
