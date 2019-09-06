using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/item")]
public class Item : ScriptableObject
{
    public string itemName = "New Item";
    public Sprite icon = null;
    public bool isEquipable = false;

}
