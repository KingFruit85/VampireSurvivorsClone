using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour 
{
  public Slider Slider;
  public Color Low;
  public Color High;
  public Vector3 Offset;

  private void Start() 
  {
    PlayerHealth.OnHealthChange += PlayerHealth_OnHealthChange;
    var startHealth = transform.parent.GetComponent<PlayerHealth>().maxHealth; 
    Slider.maxValue = startHealth;
    Slider.value = startHealth;
  }

  private void PlayerHealth_OnHealthChange(int currentHealth, int maxHealth)
  {
    // Slider.gameObject.SetActive(currentHealth <= maxHealth);
    Slider.value = currentHealth;
    Slider.maxValue = maxHealth;

    Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue);
  }
}