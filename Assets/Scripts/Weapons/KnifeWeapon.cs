using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeWeapon : MonoBehaviour, IAbility
{
    public GameObject Player;
    float TimeOfLastAttack;
    public float AttackDelay;
    public float Damage = 4;
    public Sprite Icon;
    public int CurrentAbilityLevel = 1;
    public const string AbilityName = "Throwing Knives";
    const string LevelOneDescription = "The player shoots a knife out in front of them";
    const string LevelTwoDescription = "The knife speed increases";
    const string LevelThreeDescription = "You now shoot two knives";

    public List<GameObject> Knives;
    public GameObject Knife;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        AttackDamageIncrease.DamageIncrease += AttackDamageIncrease_OnDamageIncrease;
    }

    void Start()
    {
        Knives.Add(Knife);
        Shoot();
    }

    void OnDestory()
    {
        AttackDamageIncrease.DamageIncrease -= AttackDamageIncrease_OnDamageIncrease;
    }

    void AttackDamageIncrease_OnDamageIncrease(float increase)
    {
        foreach (var knife in Knives)
        {
            increase = Damage * increase;
            Damage += increase;
            knife.GetComponent<Knife>().AddDamage(Damage);
            Debug.Log($"Increasing damage for {knife.name}");
        }
    }

    void AddKnife()
    {
        GameObject newKnife = Instantiate(Knife, Player.transform.position, Quaternion.identity, Player.transform);
        Knives.Add(newKnife);
    }

    void Shoot()
    {
        foreach (var knive in Knives)
        {
            Instantiate(knive, Player.transform.position, Quaternion.identity, Player.transform);
        }
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

    public string GetAbilityDescription(int level)
    {
        string description = string.Empty;

        switch (level)
        {
            case 1: description = LevelOneDescription; break;
            case 2: description = LevelTwoDescription; break;
            case 3: description = LevelThreeDescription; break;
        }

        return description;
    }

    public Sprite GetAbilityIcon()
    {
        return Icon;
    }

    public void LevelUpAbility()
    {
        foreach (var knife in Knives)
        {
            var knifeScript = knife.GetComponent<Knife>();
            switch (CurrentAbilityLevel)
            {
                case 1: break;

                case 2:
                    knifeScript.AddSpeed(0.05f);
                    break;

                case 3:
                    AddKnife();
                    break;
            }
        }
        CurrentAbilityLevel++;
    }

    public int GetAbilityLevel()
    {
        return CurrentAbilityLevel;
    }
}
