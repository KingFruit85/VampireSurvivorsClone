using System;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    public int currentExperience;
    public int XPToNextLevelUp;
    public static event Action LevelUpEvent;

    private void Start()
    {
        currentExperience = 0;
        XPToNextLevelUp = 10;
    }

    public void AddXp(int amountToAdd)
    {

        currentExperience += amountToAdd;
        if (currentExperience >= XPToNextLevelUp)
        {
            LevelUpEvent?.Invoke();
            XPToNextLevelUp += 50;
        }
    }
}