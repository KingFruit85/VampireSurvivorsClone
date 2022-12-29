using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
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
}
