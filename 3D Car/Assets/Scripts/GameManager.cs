using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private List<ItemBase> _ItemBases;

    // Event to notify when the score changes
    public event Action< List<ItemBase> > OnItemListChanged;

    private void Awake()
    {
        if (Instance != null)
        {
            print("Another instance of GameManager already exists. Destroying this one.");
            return;
        }

        // Implement singleton pattern
        Instance = this;
        _ItemBases = new List<ItemBase>();

    }


    public void addItem(ItemBase itemBase)
    {
        if( _ItemBases != null)
        {
            _ItemBases.Add(itemBase);

            // Notify subscribers about the score change
            OnItemListChanged?.Invoke(_ItemBases);
        }
    }

    public void removeItem(ItemBase itemBase)
    {
        if (_ItemBases != null && _ItemBases.Contains(itemBase))
        {
            _ItemBases.Remove(itemBase);
            // Notify subscribers about the score change
            OnItemListChanged?.Invoke(_ItemBases);
        }
        else
        {
            print("ItemBase not found in the list.");
        }
    }

    public List<ItemBase> getItemBases()
    {
        return _ItemBases;
    }


}
