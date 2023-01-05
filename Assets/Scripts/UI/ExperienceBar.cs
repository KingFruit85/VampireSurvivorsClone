using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    public Camera MainCamera;
    public Slider experienceBar;
    public TMP_Text LevelUpText;
    public int PlayerLevel = 1;

    void Start()
    {
        PlayerExperience.ExperienceChange += PlayerExperience_OnExperienceChange;
        PlayerExperience.LevelUpEvent += PlayerExperience_OnLevelUpEvent;
        LevelUpText.text = $"LV {PlayerLevel}";
    }

    void PlayerExperience_OnExperienceChange(int currentExperience, int XPToNextLevelUp)
    {
        float experiencePercentage = (float)currentExperience / XPToNextLevelUp;
        experienceBar.value = experiencePercentage;
    }

    void PlayerExperience_OnLevelUpEvent()
    {
        PlayerLevel++;
        LevelUpText.text = $"LV {PlayerLevel}";
        experienceBar.value = 0;
    }

}
