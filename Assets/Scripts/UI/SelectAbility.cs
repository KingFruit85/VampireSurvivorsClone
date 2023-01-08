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
                if (Player.transform.Find(abilityOne.name))
                {
                    Player.transform.Find(abilityOne.name).GetComponent<IAbility>().LevelUpAbility();
                }
                else
                {
                    GameObject ab1 = Instantiate(abilityOne, Player.transform.position, Quaternion.identity, Player.transform);
                    ab1.name = abilityOne.name;
                }

                break;

            case "OptionTwo":
                var abilityTwo = PanelManager.PickedAbilities[1];
                if (Player.transform.Find(abilityTwo.name))
                {
                    Player.transform.Find(abilityTwo.name).GetComponent<IAbility>().LevelUpAbility();
                }
                else
                {
                    GameObject ab2 = Instantiate(abilityTwo, Player.transform.position, Quaternion.identity, Player.transform);
                    ab2.name = abilityTwo.name;
                }
                break;

            case "OptionThree":
                var abilityThree = PanelManager.PickedAbilities[2];
                if (Player.transform.Find(abilityThree.name))
                {
                    Player.transform.Find(abilityThree.name).GetComponent<IAbility>().LevelUpAbility();
                }
                else
                {
                    GameObject ab3 = Instantiate(abilityThree, Player.transform.position, Quaternion.identity, Player.transform);
                    ab3.name = abilityThree.name;
                }
                break;

        }

        PanelManager.DisableLevelUpPanel();

    }
}
