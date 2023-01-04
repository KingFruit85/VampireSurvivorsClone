using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMonsterKills : MonoBehaviour
{
    public TMP_Text MonsterKillCounterText;
    public int MonsterKillCounter = 0;

    void Start()
    {
        EnemyHealth.MonsterDeath += EnemyHealth_OnMonsterDeath;
    }

    void EnemyHealth_OnMonsterDeath()
    {
        MonsterKillCounter++;
        MonsterKillCounterText.text = MonsterKillCounter.ToString();
    }


}
