using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpPanelManager : MonoBehaviour
{
    public List<GameObject> LevelUpAbilities;
    public GameObject Player;
    public GameObject Panel;
    public List<GameObject> Buttons;

    public List<GameObject> PickedAbilities;

    void Start()
    {
        PlayerExperience.LevelUpEvent += PlayerExperience_OnLevelUpEvent;
        PlayerHealth.GameOver += PlayerHealth_OnGameover;
    }
    void PlayerHealth_OnGameover()
    {
        PlayerExperience.LevelUpEvent -= PlayerExperience_OnLevelUpEvent;
    }

    void PlayerExperience_OnLevelUpEvent()
    {
        EnableLevelUpPanel();
    }

    public void EnableLevelUpPanel()
    {
        GetRandomAbilities();
        Panel.SetActive(true);
    }

    public void DisableLevelUpPanel()
    {
        PickedAbilities = new List<GameObject>();
        Panel.SetActive(false);
    }

    void OnEnable()
    {
        GetRandomAbilities();
    }

    void SetButtonData(GameObject ability, GameObject button)
    {
        IAbility thisAbility = ability.transform.GetComponentInChildren<IAbility>();
        int abilityLevel = 1;

        // check if character already has ability
        if (Player.transform.Find(ability.name))
        {
            Debug.Log("Player already has a ability, leveling it up!");
            abilityLevel = Player.transform.Find(ability.name).GetComponent<IAbility>().GetAbilityLevel() + 1;
        }

        button.transform.Find("IsAbilityNew").GetComponent<TMP_Text>().text
            = abilityLevel == 1 ? "New!" : $"Level {abilityLevel.ToString()}";

        button.transform.Find("AbilityName").GetComponent<TMP_Text>().text
            = thisAbility.GetAbilityName();

        button.transform.Find("AbilityDescription").GetComponent<TMP_Text>().text
            = thisAbility.GetAbilityDescription(abilityLevel);

        button.transform.Find("AbilityIcon").GetComponent<Image>().sprite
            = thisAbility.GetAbilityIcon();

    }

    void GetRandomAbilities()
    {
        var rng = new System.Random();

        PickedAbilities = LevelUpAbilities.OrderBy(a => rng.Next()).ToList().Take(3).ToList();

        int counter = 0;

        foreach (var button in Buttons)
        {
            SetButtonData(PickedAbilities[counter], button);
            counter++;
        }
    }
}
