using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    InventoryManager inventoryManager;
    private void Start()
    {
        inventoryManager = GetComponent<InventoryManager>();
    }
    public bool crafting(Item item)
    {
        if (!CheckCraftableArea(item)) { return false; }
        for (int i = 0;i<item.ingredients.Count;i++)
        {
            if (inventoryManager.FindItemInSlot(item.ingredients[i].itemID)< item.ingredients[i].amount) { return false; }
        }
        for (int i = 0; i < item.ingredients.Count; i++)
        {
            inventoryManager.DeleteItem(item.ingredients[i].itemID, item.ingredients[i].amount);
        }
        inventoryManager.AddItem(item);
        return true;
    }

    public bool CheckCraftableArea(Item item)
    {
        //check item.craftPlace == space player in right now;
        return true;
    }
}
