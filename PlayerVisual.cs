using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private SpriteRenderer sr;

    private int currentIndex = -1;
    private ShipData ship;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        // lấy tàu đã chọn
        ship = GameData.shipData;

        if (ship == null)
        {
            Debug.LogError("Chưa có ShipData!");
            return;
        }

        // bắt đầu LV1
        SetSprite(0);
    }

    public void UpdateSprite(int score)
    {
        int index = 0;

        for (int i = 0; i < ship.thresholds.Length; i++)
        {
            if (score >= ship.thresholds[i])
                index = i + 1;
        }
        index = Mathf.Clamp(index, 0, ship.levelSprites.Length - 1);
        SetSprite(index);
    }

    void SetSprite(int index)
    {
        index = Mathf.Clamp(index, 0, ship.levelSprites.Length - 1);
        if (index == currentIndex) return;

        currentIndex = index;

        sr.sprite = ship.levelSprites[index];
    }
}