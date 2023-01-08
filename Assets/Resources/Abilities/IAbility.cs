using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbility
{
    public string GetAbilityName();
    public string GetAbilityDescription(int level);
    public Sprite GetAbilityIcon();
    public void LevelUpAbility();
    public int GetAbilityLevel();

}
