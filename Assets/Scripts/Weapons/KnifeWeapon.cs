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
    public int MaxAbilityLevel = 9;
    public const string AbilityName = "Throwing Knives";
    const string LevelOneDescription = "The player shoots a knife out in front of them";
    const string LevelTwoDescription = "The knife speed increases";
    const string LevelThreeDescription = "You now shoot two knives";
    const string LevelFourDescription = "You now shoot thee knives and knives pass through one more enemy";
    const string LevelFiveDescription = "You now shoot four knives";
    const string LevelSixDescription = "You now shoot five knives and knives pass through one more enemy";
    const string LevelSevenDescription = "You now shoot six knives";
    const string LevelEightDescription = "You now shoot seven knives and knives pass through one more enemy";
    const string LevelNineDescription = "You now shoot eight knives";
    public static event Action<GameObject> MaxAbilityLevelReached;


    public List<GameObject> Knives;
    public GameObject Knife;

    public int EnemiesKnifeCanPassThrough = 0;

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
        }
    }

    void AddKnife()
    {
        // GameObject newKnife = Instantiate(Knife, Player.transform.position, Quaternion.identity, Player.transform);
        // newKnife.name = Knife.name;
        Knives.Add(Knife);
    }

    void Shoot()
    {

        foreach (var knife in Knives)
        {
            var rndX = Player.transform.position.x + UnityEngine.Random.Range(-.5f, .5f);
            var rndY = Player.transform.position.y + UnityEngine.Random.Range(-.5f, .5f);

            var spawnPosition = Knives.Count > 1 ? new Vector3(rndX, rndY, 0) : Player.transform.position;
            Instantiate(knife, spawnPosition, Quaternion.identity, Player.transform);
            TimeOfLastAttack = Time.time;
        }
    }

    void Update()
    {
        if (Time.time >= (TimeOfLastAttack + AttackDelay))
        {
            Shoot();
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
            case 4: description = LevelFourDescription; break;
            case 5: description = LevelFiveDescription; break;
            case 6: description = LevelSixDescription; break;
            case 7: description = LevelSevenDescription; break;
            case 8: description = LevelEightDescription; break;
            case 9: description = LevelNineDescription; break;
        }

        return description;
    }

    public Sprite GetAbilityIcon()
    {
        return Icon;
    }

    public void LevelUpAbility()
    {
        CurrentAbilityLevel++;

        switch (CurrentAbilityLevel)
        {
            case 1: break;

            case 2:
                AttackDelay -= .25f;
                break;

            case 3:
                AddKnife();
                break;
            case 4:
                AddKnife();
                EnemiesKnifeCanPassThrough += 1;
                break;
            case 5:
                AddKnife();
                break;
            case 6:
                AddKnife();
                EnemiesKnifeCanPassThrough += 1;
                break;
            case 7:
                AddKnife();
                break;
            case 8:
                AddKnife();
                EnemiesKnifeCanPassThrough += 1;
                break;
            case 9:
                AddKnife();
                MaxAbilityLevelReached?.Invoke(gameObject);
                break;

        }
    }

    public int GetAbilityLevel()
    {
        return CurrentAbilityLevel;
    }
}
