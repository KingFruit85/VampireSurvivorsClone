using UnityEngine;

public class XpPickup : MonoBehaviour, IXpPickupable 
{
    public int xpAmount {get; private set;}

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Add XP to player - to be implemented
            Destroy(gameObject);
            other.transform.GetComponent<PlayerController>().AddXp(5);
        }
    }

    public void GiveXP(PlayerExperience playerExperience)
    {
        playerExperience.AddXp(xpAmount);
        Debug.Log("XP Given");
    }
}
