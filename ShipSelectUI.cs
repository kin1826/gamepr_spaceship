using UnityEngine;
using UnityEngine.UI;

public class ShipSelectUI : MonoBehaviour
{
    public Image previewImage; // ảnh hiển thị tàu
    [Header("Level Images")]
    public Image[] levelImages; // 5 ảnh nhỏ
    public Button[] buttons;
    
    private ShipData currentShip;
    
    public void SelectShip(ShipData ship)
    {
        currentShip = ship;
        
        // lưu tàu đã chọn
        GameData.shipData = ship;

        // hiển thị sprite LV5 (max)
        previewImage.sprite = ship.levelSprites[
            ship.levelSprites.Length - 1
        ];
        
        
        
        for (int i = 0; i < levelImages.Length; i++)
        {
            if (i < ship.levelSprites.Length)
            {
                levelImages[i].sprite = ship.levelSprites[i];
            }
        }
        
        // lưu lại
        GameData.Save();
    }
    
    // 👉 hàm khi click vào từng level
    public void OnClickLevel(int index)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.clickSound);
        if (currentShip == null) return;

        if (index >= 0 && index < currentShip.levelSprites.Length)
        {
            previewImage.sprite = currentShip.levelSprites[index];
            HighlightLevel(index);
        }
    }
    
    void HighlightLevel(int index)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].image.color = (i == index) ? Color.red : Color.white;
        }
    }
}