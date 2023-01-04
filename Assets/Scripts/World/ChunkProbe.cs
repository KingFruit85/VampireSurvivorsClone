using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkProbe : MonoBehaviour
{
    public Collider2D[] ProbeResults;
    GameObject MyDetector;

    void Update()
    {
        ProbeResults = Physics2D.OverlapCircleAll(transform.position, 1.0f, LayerMask.GetMask("Default"));
        if (ProbeResults.Length > 0)
        {
            try
            {
                MyDetector.SetActive(false);
            }
            catch (System.Exception)
            {
            }
            try
            {
                gameObject.SetActive(false);
            }
            catch (System.Exception)
            {
            }
        }
    }

    public bool CheckIfOccupied()
    {
        ProbeResults = Physics2D.OverlapCircleAll(transform.position, 1.0f, LayerMask.GetMask("Default"));
        if (ProbeResults.Length > 0)
        {
            MyDetector.SetActive(false);
            gameObject.SetActive(false);
            return true;
        }

        return false;
    }

    public void SetMyDetector(GameObject detector)
    {
        MyDetector = detector;
    }
}
