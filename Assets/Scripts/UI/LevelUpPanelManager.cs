using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpPanelManager : MonoBehaviour
{
    public List<GameObject> LevelUpAbilities;

    public GameObject Panel;
    public GameObject OptionOne;
    public GameObject OptionTwo;
    public GameObject OptionThree;
    public GameObject OptionFour;

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
        Panel.SetActive(true);
    }

    public void DisableLevelUpPanel()
    {
        Panel.SetActive(false);
    }

    void OnEnable()
    {
        GetRandomAbilities();
    }

    void GetRandomAbilities()
    {
        var rng = new System.Random();

        PickedAbilities = LevelUpAbilities.OrderBy(a => rng.Next()).ToList().Take(3).ToList();

        // Set first button details
        OptionOne.transform.Find("AbilityIcon").GetComponent<Image>().sprite =
        PickedAbilities[0].transform.GetComponent<IAbility>().GetAbilityIcon();

        OptionOne.transform.Find("AbilityName").GetComponent<TMP_Text>().text =
        PickedAbilities[0].transform.GetComponent<IAbility>().GetAbilityName();

        OptionOne.transform.Find("AbilityDescription").GetComponent<TMP_Text>().text =
        PickedAbilities[0].transform.GetComponent<IAbility>().GetAbilityDescription(1); // placeholder level

        // TODO: Check player object for existing abilities to determine if the New tag should be enabled/disabled

        // Set Second button details
        OptionTwo.transform.Find("AbilityIcon").GetComponent<Image>().sprite =
        PickedAbilities[1].transform.GetComponent<IAbility>().GetAbilityIcon();

        OptionTwo.transform.Find("AbilityName").GetComponent<TMP_Text>().text =
        PickedAbilities[1].transform.GetComponent<IAbility>().GetAbilityName();

        OptionTwo.transform.Find("AbilityDescription").GetComponent<TMP_Text>().text =
        PickedAbilities[1].transform.GetComponent<IAbility>().GetAbilityDescription(1); // placeholder level

        // Set Third button details
        OptionThree.transform.Find("AbilityIcon").GetComponent<Image>().sprite =
        PickedAbilities[2].transform.GetComponent<IAbility>().GetAbilityIcon();

        OptionThree.transform.Find("AbilityName").GetComponent<TMP_Text>().text =
        PickedAbilities[2].transform.GetComponent<IAbility>().GetAbilityName();

        OptionThree.transform.Find("AbilityDescription").GetComponent<TMP_Text>().text =
        PickedAbilities[2].transform.GetComponent<IAbility>().GetAbilityDescription(1); // placeholder level

        // TODO: Set Forth button details if the players luck is high enough

    }
}
