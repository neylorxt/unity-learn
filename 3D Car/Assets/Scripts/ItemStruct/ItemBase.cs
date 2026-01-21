using UnityEngine;

// Define a ScriptableObject to hold item data
[CreateAssetMenu(fileName = "Item_", menuName = "Create Item/New Item")]
public class ItemBase : ScriptableObject
{
    public string itemName;
    public string stationName;
}
