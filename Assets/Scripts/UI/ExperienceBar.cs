using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    public Camera MainCamera;
    public GameObject Player;
    public Image ExperienceBarImage;
    public TMP_Text LevelUpText;
    public int PlayerLevel = 1;

    void Start()
    {
        PlayerExperience.ExperienceChange += PlayerExperience_OnExperienceChange;
        PlayerExperience.LevelUpEvent += PlayerExperience_OnLevelUpEvent;
        ExperienceBarImage.fillAmount = 0f;
        LevelUpText.text = $"LV {PlayerLevel}";
    }

    void PlayerExperience_OnExperienceChange(int currentExperience)
    {
        ExperienceBarImage.fillAmount = currentExperience / 100f;
    }

    void PlayerExperience_OnLevelUpEvent()
    {
        PlayerLevel++;
        LevelUpText.text = $"LV {PlayerLevel}";
    }

}
