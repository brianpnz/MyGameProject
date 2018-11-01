using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInventoryUI : MonoBehaviour {

    public Transform itemsParent;
    public GameObject npcinventoryUI;

    NPCInventory npcinventory;

    NPCInventorySlot[] slots;

	// Use this for initialization
	void Start () {
        npcinventory = NPCInventory.instance;

        // Add our UpdateUI method to the inventory callback stack
        // so that when the inventory is updated, this UpdateUI gets called.
        npcinventory.OnNPCItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<NPCInventorySlot>();
	}

    private void Update()
    {
        // If the inventory key is pressed
        // -- Check Edit > Project Seetings > Input
        if(Input.GetButtonDown("Inventory"))
        {
            // Toggle the UI state
            npcinventoryUI.SetActive(!npcinventoryUI.activeSelf);
        }

    }
    // Update is called once per frame
    void UpdateUI() {

        //Debug on updateUI
        Debug.Log("Updating NPC UI");

        // 
        for(int i =0; i < slots.Length; i++)
        {
            // If there are more items to add
            if(i < npcinventory.items.Count)
            {
                //Add the item
                slots[i].AddItem(npcinventory.items[i]);
                Debug.Log("Add item to slot");
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

	}
}
