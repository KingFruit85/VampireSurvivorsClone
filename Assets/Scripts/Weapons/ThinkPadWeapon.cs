using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkPadWeapon : MonoBehaviour, IAbility
{
    public int CurrentAbilityLevel = 1;
    public int MaxAbilityLevel = 9;
    public const string AbilityName = "ThinkPad";
    const string LevelOneDescription = "A strange object circles around the player damaging enemies that touch it";
    const string LevelTwoDescription = "Another strange object appears";
    const string LevelThreeDescription = "The objects get faster and further away";
    public Sprite Icon;
    public GameObject ThinkPadObject;
    public List<GameObject> ThinkPads;
    public GameObject Player;
    public static event Action<GameObject> MaxAbilityLevelReached;
    public float ThinkPadRespawnTime = 3f; // this should probably be an event
    private float Radius = 1f;


    void Awake()
    {
        Thinkpad.HitLimitReached += Thinkpad_OnHitLimitReached;
        Player = GameObject.FindGameObjectWithTag("Player");
        AddThinkPadToOrbit(4);
        EvenlySpaceActiveThinkpads(); // call if number of thinkpads in orbit change
    }

    void Thinkpad_OnHitLimitReached(GameObject thinkPad)
    {
        thinkPad.GetComponent<Thinkpad>().HitsDealt = 0;
        StartCoroutine(TemporarilyDisableNotebook(thinkPad));
    }

    IEnumerator TemporarilyDisableNotebook(GameObject thinkPad)
    {
        thinkPad.SetActive(false);
        yield return new WaitForSeconds(ThinkPadRespawnTime);
        thinkPad.SetActive(true);
    }

    void AddThinkPadToOrbit(int count = 1)
    {
        for (int i = 0; i <= count; i++)
        {
            GameObject newPad = Instantiate(ThinkPadObject, Player.transform.position, Quaternion.identity, Player.transform);
            newPad.name = ThinkPadObject.name;
            ThinkPads.Add(newPad);
        }
    }

    void EvenlySpaceActiveThinkpads()
    {
        for (int i = 0; i < ThinkPads.Count; i++)
        {
            float angle = i * Mathf.PI * 2 / ThinkPads.Count;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * Radius;
            ThinkPads[i].transform.position = pos;
        }
    }

    public string GetAbilityName()
    {
        return AbilityName;
    }

    public string GetAbilityDescription(int level)
    {
        string Description = string.Empty;

        switch (level)
        {
            case 1: Description = LevelOneDescription; break;
            case 2: Description = LevelTwoDescription; break;
            case 3: Description = LevelThreeDescription; break;
            case 4: Description = LevelThreeDescription; break;
            case 5: Description = LevelThreeDescription; break;
            case 6: Description = LevelThreeDescription; break;
            case 7: Description = LevelThreeDescription; break;
            case 8: Description = LevelThreeDescription; break;
            case 9: Description = LevelThreeDescription; break;
        }

        return Description;
    }

    public Sprite GetAbilityIcon()
    {
        return Icon;
    }

    public void LevelUpAbility()
    {
        CurrentAbilityLevel++;

        Thinkpad thinkPadScript;

        switch (CurrentAbilityLevel)
        {
            case 1:
                break;

            case 2:
                AddThinkPadToOrbit();
                break;

            case 3:
                AddThinkPadToOrbit();
                foreach (var thinkpad in ThinkPads)
                {
                    thinkPadScript = thinkpad.GetComponent<Thinkpad>();
                    thinkPadScript.AddSpeed(1f);
                    thinkPadScript.AddRadius(.2f);
                }
                break;
            case 4:
                AddThinkPadToOrbit();
                foreach (var thinkpad in ThinkPads)
                {
                    thinkPadScript = thinkpad.GetComponent<Thinkpad>();
                    thinkPadScript.AddSpeed(1f);
                }
                break;
            case 5:
                AddThinkPadToOrbit();
                foreach (var thinkpad in ThinkPads)
                {
                    thinkPadScript = thinkpad.GetComponent<Thinkpad>();
                    thinkPadScript.AddSpeed(1f);
                }
                break;
            case 6:
                AddThinkPadToOrbit();
                foreach (var thinkpad in ThinkPads)
                {
                    thinkPadScript = thinkpad.GetComponent<Thinkpad>();
                    thinkPadScript.AddSpeed(1f);
                    thinkPadScript.AddRadius(.2f);
                }
                break;
            case 7:
                AddThinkPadToOrbit();
                foreach (var thinkpad in ThinkPads)
                {
                    thinkPadScript = thinkpad.GetComponent<Thinkpad>();
                    thinkPadScript.AddSpeed(1f);
                }
                break;
            case 8:
                AddThinkPadToOrbit();
                foreach (var thinkpad in ThinkPads)
                {
                    thinkPadScript = thinkpad.GetComponent<Thinkpad>();
                    thinkPadScript.AddSpeed(1f);
                }
                break;
            case 9:
                MaxAbilityLevelReached?.Invoke(gameObject);
                AddThinkPadToOrbit();
                foreach (var thinkpad in ThinkPads)
                {
                    thinkPadScript = thinkpad.GetComponent<Thinkpad>();
                    thinkPadScript.AddSpeed(2f);
                }
                break;
        }
    }

    public int GetAbilityLevel()
    {
        return CurrentAbilityLevel;
    }
}
