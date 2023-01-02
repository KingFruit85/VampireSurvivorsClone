using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    public int currentExperience;
    public int XPToNextLevelUp;
    public GameObject LevelUpPanel;

    private void Start()
    {
        currentExperience = 0;
        XPToNextLevelUp = 10;
    }

    public void AddXp(int amountToAdd)
    {
        currentExperience += amountToAdd;
    }

    void LevelUp()
    {
        LevelUpPanel.SetActive(true);
        XPToNextLevelUp += 50;
    }

    void Update()
    {
        if (currentExperience >= XPToNextLevelUp)
        {
            LevelUp();
        }
    }
}