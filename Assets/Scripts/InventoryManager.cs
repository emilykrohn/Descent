using System.Collections.Generic;
using UnityEngine;

// Requirement #4
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; //public access


    public List<Item> items = new List<Item>(); 

    void Awake()
    {
        // Singleton pattern- only one inventorymanager can exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //add the item to inventory
    public void AddItem(Item newItem)
    {
        //check if we already have this item
        Item existingItem = items.Find(item => item.itemID == newItem.itemID);

        if (existingItem != null)
        {
            
            existingItem.quantity += newItem.quantity;
        }
        else
        {
            //add new item
            items.Add(newItem);
        }

        Debug.Log($"Added {newItem.quantity} {newItem.itemName} to inventory");
    }

    //delete an item from inventory
    public void RemoveItem(string itemID, int quantityToRemove = 1)
    {
        Item itemToRemove = items.Find(item => item.itemID == itemID);

        if (itemToRemove != null)
        {
            itemToRemove.quantity -= quantityToRemove;

            if (itemToRemove.quantity <= 0)
            {
                items.Remove(itemToRemove);
            }

            Debug.Log($"Removed {quantityToRemove} {itemToRemove.itemName} from inventory");
        }
    }

    
    public void UseItem(string itemID)
    {
        Item itemToUse = items.Find(item => item.itemID == itemID);

        if (itemToUse != null && itemToUse.type == ItemType.Consumable)
        {
            
            if (itemToUse.healthBonus != 0)
            {
                Debug.Log($"Healed for {itemToUse.healthBonus} HP!");
            }

            if (itemToUse.damageBonus != 0)
            {
                Debug.Log($"Damage boosted by {itemToUse.damageBonus}!");
            }

            RemoveItem(itemID, 1);
        }
    }

    public bool HasItem(string itemID)
    {
        return items.Exists(item => item.itemID == itemID);
    }

    //returns the  item count
    public int GetItemCount(string itemID)
    {
        Item item = items.Find(i => i.itemID == itemID);
        return item != null ? item.quantity : 0;
    }
}