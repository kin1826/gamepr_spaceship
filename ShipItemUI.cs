using UnityEngine;
using UnityEngine.UI;

public class ShipItemUI : MonoBehaviour
{
    public Image icon;

    private ShipData shipData;
    private ShipSelectUI selectUI;

    public void Setup(ShipData data, ShipSelectUI ui)
    {
        shipData = data;
        selectUI = ui;

        // hiển thị lv5
        icon.sprite = data.levelSprites[
            data.levelSprites.Length - 1
        ];

        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        selectUI.SelectShip(shipData);
        AudioManager.instance.PlaySFX(AudioManager.instance.clickSound);
    }
}