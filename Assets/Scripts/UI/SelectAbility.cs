using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectAbility : MonoBehaviour
{
    public GameObject Player;

    public void AddAbilityToCharacter()
    {
        var panel = transform.parent.GetComponent<LevelUpPanelManager>();

        switch (transform.name)
        {
            case "OptionOne":
                var abilityOne = panel.PickedAbilities[0];
                Instantiate(abilityOne, Player.transform.position, Quaternion.identity, Player.transform);
                break;

            case "OptionTwo":
                var abilityTwo = panel.PickedAbilities[1];
                Instantiate(abilityTwo, Player.transform.position, Quaternion.identity, Player.transform);
                break;

            case "OptionThree":
                var abilityThree = panel.PickedAbilities[2];
                Instantiate(abilityThree, Player.transform.position, Quaternion.identity, Player.transform);
                break;

                // case "OptionFour":
                //     var abilityFour = panel.PickedAbilities[0];
                //     Instantiate(abilityFour, Player.transform.position, Quaternion.identity, Player.transform);
                //     break;
        }

        panel.gameObject.SetActive(false);

    }
}
