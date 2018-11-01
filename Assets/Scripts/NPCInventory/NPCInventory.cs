using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInventory : MonoBehaviour {

    #region Singleton
    public static NPCInventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of NPCInventory found!");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnNPCItemChanged();
    public OnNPCItemChanged OnNPCItemChangedCallback;

    public int space = 20;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough room");
                return false;
            }

            Debug.Log("Add item to NPC inventory");
            items.Add(item);

            if (OnNPCItemChangedCallback != null)
            {
                OnNPCItemChangedCallback.Invoke();
            }
            else
            {
                Debug.Log("Call back is null");
            }
        }

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (OnNPCItemChangedCallback != null)
            OnNPCItemChangedCallback.Invoke();
    }

}
