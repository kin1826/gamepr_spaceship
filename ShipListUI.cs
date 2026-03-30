using UnityEngine;

public class ShipListUI : MonoBehaviour
{
    public Transform content;
    public GameObject itemPrefab;
    public ShipData[] ships;

    public ShipSelectUI selectUI;

    void Start()
    {
        foreach (var ship in ships)
        {
            GameObject obj = Instantiate(itemPrefab, content);

            var item = obj.GetComponent<ShipItemUI>();
            item.Setup(ship, selectUI);
        }
    }
}