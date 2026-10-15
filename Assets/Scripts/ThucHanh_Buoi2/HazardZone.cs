using UnityEngine;

public class HazardZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Player enter Hazard Zone");
        }
    }

     void OnTriggerExit2D(Collider2D collider) 
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Player exit Hazard Zone");
        }
    }
}
