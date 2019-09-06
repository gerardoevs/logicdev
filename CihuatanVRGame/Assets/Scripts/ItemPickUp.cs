using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp() {
        Debug.Log("Item:" + item.itemName);
        Inventory.Instance.Add(item);
        Destroy(gameObject);
    }
}
