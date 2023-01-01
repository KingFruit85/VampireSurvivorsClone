using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour 
{
  public Camera MainCamera;
  public Color Low;
  public Color High;
  public int MaxHealth;
  public int CurrentHealth;
  public float Offset = -0.5f;
  public GameObject Player;
  public Image HealthBarImage;

  private void Start() 
  {
    PlayerHealth.OnHealthChange += PlayerHealth_OnHealthChange;
    var startHealth = Player.GetComponent<PlayerHealth>().maxHealth;
  }

  private void LateUpdate() 
  {
    transform.position = MainCamera.WorldToScreenPoint(Player.transform.position + Vector3.up * Offset);  
  }

  private void PlayerHealth_OnHealthChange(int currentHealth, int maxHealth)
  {
    HealthBarImage.fillAmount = currentHealth / 100f;
    HealthBarImage.color = Color.Lerp(Low, High, currentHealth / 100f);
  }
}