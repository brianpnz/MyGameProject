using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NPCInventorySlot : MonoBehaviour, IDropHandler
{

    public Image icon;
    public Button removeButton;
    Item item;

    // Adds a new item to this slot
    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void onRemoveButton()
    {
        NPCInventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            Debug.Log("Dropping item");

        //  Get the static DragHandler object and the item, 
        // then set as a child of this transform
            DragHandler.itemBeingDragged.transform.SetParent(transform);
        }

    }
}