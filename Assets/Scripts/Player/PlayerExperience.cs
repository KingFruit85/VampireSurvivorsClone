using UnityEngine;

public class PlayerExperience : MonoBehaviour {
  public int currentExperience;

  private void Start() 
  {
    currentExperience = 0;
  }  

  public void AddXp(int amountToAdd)
  {
    currentExperience += amountToAdd;
  }
}