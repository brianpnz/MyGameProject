using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;
    public GameObject inventoryUI;

    Inventory inventory;

    InventorySlot[] slots;

	// Use this for initialization
	void Start () {
        inventory = Inventory.instance;

        // Add our UpdateUI method to the inventory callback stack
        // so that when the inventory is updated, this UpdateUI gets called.
        inventory.OnItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}

    private void Update()
    {
        // If the inventory key is pressed
        // -- Check Edit > Project Seetings > Input
        if(Input.GetButtonDown("Inventory"))
        {
            // Toggle the UI state
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
    // Update is called once per frame
    void UpdateUI() {

        //Debug on updateUI
        Debug.Log("Updating UI");

        // 
        for(int i =0; i < slots.Length; i++)
        {
            // If there are more items to add
            if(i < inventory.items.Count)
            {
                //Add the item
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

	}
}
