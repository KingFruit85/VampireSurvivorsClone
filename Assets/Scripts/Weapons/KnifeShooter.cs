using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeShooter : MonoBehaviour, IAbility
{
    public GameObject Knife;
    public GameObject Player;
    float TimeOfLastAttack;
    public float AttackDelay;
    public int Damage = 2;
    public Sprite Icon;
    public const string AbilityName = "Throwing Knives";
    public const string Description = "The player shoots knives in front of them";


    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
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

    public string GetAbilityName()
    {
        return AbilityName;
    }

    public string GetAbilityDescription()
    {
        return Description;
    }

    public Sprite GetAbilityIcon()
    {
        return Icon;
    }

    public int GetAbilityDamage()
    {
        return Damage;
    }
}
