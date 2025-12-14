using UnityEngine;

[CreateAssetMenu(fileName = "Item_", menuName = "Create Item/New Item")]
public class ItemBase : ScriptableObject
{
    public string itemName;
    public string stationName;
}
