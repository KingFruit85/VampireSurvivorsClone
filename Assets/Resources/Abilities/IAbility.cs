using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbility
{
    public string GetAbilityName();
    public string GetAbilityDescription();
    public Sprite GetAbilityIcon();
    public int GetAbilityDamage();
}
