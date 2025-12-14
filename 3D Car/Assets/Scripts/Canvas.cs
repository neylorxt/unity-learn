using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    public Text _TextScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.OnItemListChanged += UpdateItemBases;
        UpdateItemBases(GameManager.Instance.getItemBases() ); // init
    }

    // Update is called once per frame
    void OnDisable()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnItemListChanged -= UpdateItemBases;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateItemBases(List<ItemBase> itemBases)
    {
        int count = (itemBases != null) ? itemBases.Count : 0;
        _TextScore.text = "Items : " + count;
    }

}
