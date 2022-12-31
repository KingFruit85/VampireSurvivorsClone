using UnityEngine;

public class XpPickup : MonoBehaviour, IPickupable 
{
    public int xpAmount;

    public XpPickup(int amount) => xpAmount = amount;

    public void OnPickup(Collider2D other)
    {
        if (other.transform.TryGetComponent<PlayerExperience>(out var playerExperience))
        {
            playerExperience.AddXp(xpAmount);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("here");
        Debug.Log(other.tag);


        if (other.tag == "Player")
        {
            OnPickup(other);
        }
    }
}
