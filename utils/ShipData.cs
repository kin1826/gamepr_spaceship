using UnityEngine;

[CreateAssetMenu(fileName = "ShipData", menuName = "Game/Ship Data")]
public class ShipData : ScriptableObject
{
    public string shipName;

    public Sprite[] levelSprites; // lv1 → lv5
    public int[] thresholds;
}
