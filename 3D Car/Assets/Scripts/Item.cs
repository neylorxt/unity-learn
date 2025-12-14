using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemBase _ItemBase;

    private void Awake()
    {
        _ItemBase.itemName = "Item_" + Random.Range(1000, 9999);
        _ItemBase.stationName = "Station_AAA";
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
            print("Item collected: " + _ItemBase.itemName);

            // Increase the score in GameManager
            GameManager.Instance.addItem(_ItemBase);
            // Destroy the item after collection
            Destroy(gameObject);
        }
    }
}
