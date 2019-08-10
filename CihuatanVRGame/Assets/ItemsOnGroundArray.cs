using UnityEngine;

public class ItemsOnGroundArray : MonoBehaviour
{

    private GameObject[] itemsOnGround = new GameObject[5];

    private static ItemsOnGroundArray _instance;

    public static ItemsOnGroundArray Instance {
        get
        {
            if (_instance == null) {
                _instance = new ItemsOnGroundArray();
            }
            return _instance;
        }
    }

    public void AddItemToArray(GameObject item) {
        Debug.Log(itemsOnGround.Length);
        for (int i = 1; i >= itemsOnGround.Length-1; i++) {
            Debug.Log(i);
            itemsOnGround[i] = itemsOnGround[i - 1];
        }
        itemsOnGround[1] = item;

        for (int i = 0; i <= itemsOnGround.Length; i++)
        {
            Debug.Log("Item "+i+":"+itemsOnGround[i].name);
        }
    }

}
