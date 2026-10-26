using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{   
    [SerializeField]
    private GameScore gameScore;
   
    private PlayerInventory playerInventory;

   
   
   
    private void Awake()
    {
    playerInventory = GetComponent<PlayerInventory>();
    }


    void OnCollisionEnter2D(Collision2D collision) // cái này dừng lại stop object khi va chạm collision
    //void OnTriggerEnter2D(Collider2D other) cái này trigger cho đi xuyên qua, bat trigger trong editor inspector collider
    {
        Debug.Log("Phat hien va cham collision voi obstacle." + collision.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.CompareTag("Coin") && playerInventory != null)
        {   
            if (collision.gameObject.name.Contains("Silver"))
            {
                playerInventory.AddCoin(1);
                gameScore.AddScore(3);
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.name.Contains("Premium"))
            {
                playerInventory.AddCoin(1);
                gameScore.AddScore(5);
                Destroy(collision.gameObject);
            }
            else 
            {
                playerInventory.AddCoin(1);
                gameScore.AddScore(1);
                Destroy(collision.gameObject);
            }
        }

        PlayerItemPickUp itemPickup = collision.GetComponent<PlayerItemPickUp>();
        
        if (itemPickup != null)
        {
            Item item = itemPickup.CreateItem();
            playerInventory.AddItem(item);
            Debug.Log("Picked up: " + item.ItemName);
            Destroy(collision.gameObject);
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
