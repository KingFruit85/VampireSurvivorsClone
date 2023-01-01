using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour 
{
  public Camera MainCamera;
  public Color Low;
  public Color High;
  public float Offset;
  public GameObject Player;
  public Image HealthBarImage;

  private void Start() 
  {
    PlayerHealth.OnHealthChange += PlayerHealth_OnHealthChange;
    var startHealth = transform.parent.GetComponent<PlayerHealth>().maxHealth;
  }

  private void LateUpdate() 
  {
    transform.position = MainCamera.WorldToScreenPoint(Player.transform.position + Vector3.up * Offset);  
  }

  private void PlayerHealth_OnHealthChange(int currentHealth, int maxHealth)
  {
    HealthBarImage.fillAmount = 
    HealthBarImage.color = Color.Lerp(Low, High, Slider.normalizedValue);
  }
}