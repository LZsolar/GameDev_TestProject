using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefeb;

    int selectedSlot = -1;
    private void Start()
    {
        ChangeSelectedSlot(0);
    }
    private void Update()
    {
        //NEW TECHNOLOGY LEARN
        if(Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if(isNumber && number > 0 && number <9) { ChangeSelectedSlot(number-1); }
        }
        
        /*if (Input.GetKey(KeyCode.Alpha1)) { ChangeSelectedSlot(0); }
        else if (Input.GetKey(KeyCode.Alpha2)) { ChangeSelectedSlot(1); }
        else if (Input.GetKey(KeyCode.Alpha3)) { ChangeSelectedSlot(2); }
        else if (Input.GetKey(KeyCode.Alpha4)) { ChangeSelectedSlot(3); }
        else if (Input.GetKey(KeyCode.Alpha5)) { ChangeSelectedSlot(4); }
        else if (Input.GetKey(KeyCode.Alpha6)) { ChangeSelectedSlot(5); }
        else if (Input.GetKey(KeyCode.Alpha7)) { ChangeSelectedSlot(6); }
        else if (Input.GetKey(KeyCode.Alpha8)) { ChangeSelectedSlot(7); }*/
    }

    void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlot >=0)
        {
            inventorySlots[selectedSlot].Deselect();
        }
        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }

    public bool AddItem(Item item)
    {
        int maxStackedItems = item.stackableCount;
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null&& itemInSlot.item == item && itemInSlot.count < maxStackedItems)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if(itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;
    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefeb, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    public Item GetSelectedItem(bool used)
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if(itemInSlot != null)
        {
            Item item = itemInSlot.item;
            if (used) {
                itemInSlot.count--;
                if (itemInSlot.count <= 0) { 
                    Destroy(itemInSlot.gameObject);
                }
                else
                {
                    itemInSlot.RefreshCount();
                }
            }
        }
        return null;
    }
}
