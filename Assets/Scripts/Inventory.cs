using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton

    public static Inventory instance;
    void Awake ()
    {

        if (instance != null)
        {
            Debug.LogWarning("More than one Instance of Inventory found!");
            return;
        }
        instance = this;
    }

    #endregion


    // When Item is changing in inventory, trigger this delegate.
    public delegate void OnITemChanged();
    public OnITemChanged onItemChangedCallback;

    public int space = 24;

    public List<Item> items = new List<Item>();

    public bool Add (Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not Enough Space");
                return false;
            }
            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove (Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
