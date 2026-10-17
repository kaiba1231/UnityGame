using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{   
    [SerializeField] private CoinCounterUI coinCounterUI;
    private List<Item> items = new();
    [SerializeField] private InventoryUI inventoryUI;
    public IReadOnlyList<Item> Items
    {
    get { return items; }
    }

    private int coinCount;
    public int CoinCount
    {
        get
        {
            return coinCount;
        }
    }




    public void AddCoin(int amount)
    {
        if (amount <= 0)
        {
        return;
        }

    coinCount += amount;

    if (coinCounterUI != null)
        {
        coinCounterUI.SetCoinCount(coinCount);
        }

    }

    public Item FindItem(int id)
    {
        foreach (Item item in items)
        {
            if (item.Id == id) return item;
        }
        return null;
    }

    public void AddItem(Item newItem)
    {
        Item existingItem = FindItem(newItem.Id);

        if (existingItem != null)   
            existingItem.Quantity += newItem.Quantity; 
        else
            items.Add(newItem);

        RefreshUI();
    }

    public bool RemoveItem(int id, int amount)
    {
        if (amount <= 0) return false;

        Item item = FindItem(id);
        if (item == null) return false;
        if (item.Quantity < amount) return false;

        item.Quantity -= amount;
        if (item.Quantity == 0)
        {
        items.Remove(item);
        }

        RefreshUI();
        return true;
    }

    public void UseHealthPotion(PlayerHealth playerHealth)
    {
        const int healthPotionId = 1;
        bool removed = RemoveItem(healthPotionId, 1);
        if (!removed) return;

        playerHealth.Heal(25);
    }

    private void RefreshUI()
    {
        if (inventoryUI != null)
        {
        inventoryUI.Refresh(items);
        }
    }
    void Start()
    {
        if (coinCounterUI != null)
        {
        coinCounterUI.SetCoinCount(coinCount);
        }
    }

}
