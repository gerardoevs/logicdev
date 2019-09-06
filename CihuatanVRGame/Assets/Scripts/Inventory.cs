using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    #region Singleton
    public static Inventory _instance;

    public static Inventory Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    public void Add(Item item) {
        Debug.Log(item.name);
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }
}
