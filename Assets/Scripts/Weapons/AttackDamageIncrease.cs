using System;
using UnityEngine;

public class AttackDamageIncrease : MonoBehaviour, IAbility
{
    public Sprite Icon;
    public int CurrentAbilityLevel = 1;
    const string AbilityName = "Damage Increase";
    const string LevelOneDescription = "All damage increased by 5%";
    const string LevelTwoDescription = "All damage increased by 5%";
    const string LevelThreeDescription = "All damage increased by 5%";

    public static event Action<float> DamageIncrease;

    void Start()
    {
        DamageIncrease?.Invoke(0.05f);
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
        CurrentAbilityLevel++;
        DamageIncrease?.Invoke(0.05f);
    }

    public int GetAbilityLevel()
    {
        return CurrentAbilityLevel;
    }
}
