using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collider) // cái này dừng lại stop object khi va chạm collision
    //void OnTriggerEnter2D(Collider2D other) cái này trigger cho đi xuyên qua, "bat trigger trong editor inspector collider
    {
        if (collider.CompareTag("Gem"))
        {
            Debug.Log("Vat Pham" + collider.gameObject.name +  " da duoc pickup.");
           Destroy(collider.gameObject);
        }
    }
    
    
    
    
    
    
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
