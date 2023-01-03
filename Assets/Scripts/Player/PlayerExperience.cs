using System;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    public int currentExperience;
    public int XPToNextLevelUp;
    public static event Action<bool> LevelUpEvent;

    private void Start()
    {
        currentExperience = 0;
        XPToNextLevelUp = 10;
    }

    public void AddXp(int amountToAdd)
    {
        LevelUpEvent.Invoke(false);

        currentExperience += amountToAdd;
        if (currentExperience >= XPToNextLevelUp)
        {
            LevelUpEvent.Invoke(true);
            XPToNextLevelUp += 50;
        }
    }
}