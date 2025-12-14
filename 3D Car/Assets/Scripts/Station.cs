using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    [SerializeField] private ItemBase itemBaseAttendu;

    private void Awake()
    {
        itemBaseAttendu.name = "aaa";
        itemBaseAttendu.stationName = "Station_AAA";
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            List<ItemBase> itemBases = GameManager.Instance.getItemBases();
            ItemBase ItemFound = null;

            foreach (ItemBase itemBase in itemBases)
            {
                if(itemBase.stationName == itemBaseAttendu.stationName)
                {
                    ItemFound = itemBase;
                    break;
                }
            }

            if (ItemFound != null )
            {
                GameManager.Instance.removeItem(ItemFound);
                Destroy(this.gameObject);
            }
            
        }
    }
}
