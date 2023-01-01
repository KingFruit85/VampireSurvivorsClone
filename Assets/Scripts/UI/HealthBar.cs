using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Camera MainCamera;
    public Color Low;
    public Color High;
    public float Offset = -0.5f;
    public GameObject Player;
    public Image HealthBarImage;

    private void Start()
    {
        PlayerHealth.OnHealthChange += PlayerHealth_OnHealthChange;
        // HealthBarImage = transform.Find("Bar").GetComponent<Image>();
    }

    private void LateUpdate()
    {
        transform.position = MainCamera.WorldToScreenPoint(Player.transform.position + Vector3.up * Offset);
    }

    private void PlayerHealth_OnHealthChange(int currentHealth, int maxHealth)
    {
        if (currentHealth <= 0)
        {
            PlayerHealth.OnHealthChange -= PlayerHealth_OnHealthChange;
        }

        HealthBarImage.fillAmount = currentHealth / 100f;
        HealthBarImage.color = Color.Lerp(Low, High, currentHealth / 100f);
    }
}