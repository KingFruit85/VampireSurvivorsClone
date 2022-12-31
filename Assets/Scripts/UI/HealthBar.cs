using UnityEngine;

public class HealthBar : MonoBehaviour 
{
  private void Start() {
    PlayerHealth.OnHealthChange += PlayerHealth_OnHealthChange;
  }

  private void PlayerHealth_OnHealthChange(int currentHealth)
  {
    Debug.Log("Health Changed UI Update");
  }
}