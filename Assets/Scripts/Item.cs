using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemID;
    public string itemName;
    public ItemType type;
    public int quantity;
    public Sprite icon;

    
    public int healthBonus;
    public int damageBonus;
    public float speedBonus;
    public int currencyValue;
    public bool isKeyItem;

   
    public Item(string id, string name, ItemType itemType, Sprite itemIcon, int initialQuantity = 1)
    {
        itemID = id;
        itemName = name;
        type = itemType;
        icon = itemIcon;
        quantity = initialQuantity;
    }
}

public enum ItemType
{
    Consumable,
    Weapon,
    Key,
    Currency,
    Equipment
}