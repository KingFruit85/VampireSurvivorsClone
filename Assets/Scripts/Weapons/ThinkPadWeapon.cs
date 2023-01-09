using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkPadWeapon : MonoBehaviour, IAbility
{
    public int CurrentAbilityLevel = 1;
    public const string AbilityName = "ThinkPad";
    const string LevelOneDescription = "A strange object circles around the player damaging enemies that touch it";
    const string LevelTwoDescription = "Another strange object appears";
    const string LevelThreeDescription = "The objects get faster and further away";
    public Sprite Icon;
    public GameObject ThinkPad;
    public List<GameObject> ThinkPads;
    public GameObject Player;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        AddThinkPadToOrbit();
    }

    void AddThinkPadToOrbit()
    {
        GameObject newPad = Instantiate(ThinkPad, Player.transform.position, Quaternion.identity, Player.transform);
        newPad.name = ThinkPad.name;
        ThinkPads.Add(newPad);
    }

    public string GetAbilityName()
    {
        return AbilityName;
    }

    public string GetAbilityDescription(int level)
    {
        string Description = string.Empty;

        switch (level)
        {
            case 1: Description = LevelOneDescription; break;
            case 2: Description = LevelTwoDescription; break;
            case 3: Description = LevelThreeDescription; break;
        }

        return Description;
    }

    public Sprite GetAbilityIcon()
    {
        return Icon;
    }

    public void LevelUpAbility()
    {
        CurrentAbilityLevel++;

        foreach (var thinkPad in ThinkPads)
        {
            var thinkPadScript = thinkPad.GetComponent<Thinkpad>();
            switch (CurrentAbilityLevel)
            {
                case 1:
                    break;

                case 2:
                    AddThinkPadToOrbit();
                    break;

                case 3:
                    thinkPadScript.AddSpeed(2f);
                    thinkPadScript.AddRadius(1f);
                    break;
            }
        }
    }

    public int GetAbilityLevel()
    {
        return CurrentAbilityLevel;
    }
}
