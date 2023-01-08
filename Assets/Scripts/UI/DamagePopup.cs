using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    TextMeshPro TextMesh;
    float DisappearTimer;
    Color TextColor;

    void Awake()
    {
        TextMesh = transform.GetComponent<TextMeshPro>();
    }

    //Create a Damage Popup
    public static DamagePopup Create(Vector3 position, float damageAmount, bool isCrit)
    {
        Vector3 PopupSpawnPosition = new Vector3(position.x + .4f, position.y + .5f);

        GameObject PopupPrefab = Resources.Load<GameObject>("DamagePopup");

        GameObject InstantiatedPrefab = Instantiate(PopupPrefab, PopupSpawnPosition, Quaternion.identity);

        DamagePopup damagePopupScript = InstantiatedPrefab.GetComponent<DamagePopup>();

        damagePopupScript.Setup(damageAmount, isCrit);

        return damagePopupScript;
    }

    public void Setup(float damageAmount, bool isCrit)
    {
        if (isCrit)
        {
            TextMesh.color = Color.red;
            TextMesh.SetText(damageAmount.ToString() + " (critical!)");

            isCrit = false;
        }
        else
        {
            TextColor = TextMesh.color;
            TextMesh.SetText(damageAmount.ToString());
        }

        DisappearTimer = 1f;
    }

    private void Update()
    {
        float moveYSpeed = 2.0f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        DisappearTimer -= Time.deltaTime;
        if (DisappearTimer < 0)
        {
            // Start disappearing
            float disappearSpeed = 2f;
            TextColor.a -= disappearSpeed * Time.deltaTime;
            TextMesh.color = TextColor;
            if (TextColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}