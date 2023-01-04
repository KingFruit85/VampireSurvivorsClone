using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectAbility : MonoBehaviour
{
    public GameObject Player;
    public LevelUpPanelManager PanelManager;

    public void AddAbilityToCharacter()
    {

        switch (transform.name)
        {
            case "OptionOne":
                var abilityOne = PanelManager.PickedAbilities[0];
                Instantiate(abilityOne, Player.transform.position, Quaternion.identity, Player.transform);
                break;

            case "OptionTwo":
                var abilityTwo = PanelManager.PickedAbilities[1];
                Instantiate(abilityTwo, Player.transform.position, Quaternion.identity, Player.transform);
                break;

            case "OptionThree":
                var abilityThree = PanelManager.PickedAbilities[2];
                Instantiate(abilityThree, Player.transform.position, Quaternion.identity, Player.transform);
                break;

                // case "OptionFour":
                //     var abilityFour = PanelManager.PickedAbilities[0];
                //     Instantiate(abilityFour, Player.transform.position, Quaternion.identity, Player.transform);
                //     break;
        }

        PanelManager.DisableLevelUpPanel();

    }
}
