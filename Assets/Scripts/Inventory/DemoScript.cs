using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
   public InventoryManager inventoryManager;
    public CraftingManager craftingManager;
    public Item[] itemsToPickup;
    bool isInventoryOpen = false;
    public GameObject inventoryMenu;

    private void Start()
    {
        inventoryMenu.SetActive(false);
    }

    public void PickupItem(int id)
    {
        bool result = inventoryManager.AddItem(itemsToPickup[id]);
        if (result) {/*PICK UP*/ }
        else { /*INVENTORY FULL*/}
    }
    public void usedIten()
    {
        inventoryManager.GetSelectedItem(true);
    }
    public void craftIten(int id)
    {
        craftingManager.crafting(itemsToPickup[id]);
    }
    public void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        inventoryMenu.SetActive(isInventoryOpen);
    }
}
