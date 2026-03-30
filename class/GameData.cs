using System.IO;
using UnityEngine;

public class GameData
{
    public static int highScore;
    public static int currentScore;
    public static int level;

    public static ShipData shipData;

    static string path = Application.persistentDataPath + "/save.json";

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string shipName;
    }

    // LOAD
    public static void Load()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;

            // 👉 thử load ship đã lưu
            if (!string.IsNullOrEmpty(data.shipName))
            {
                shipData = Resources.Load<ShipData>("Ships/" + data.shipName);
            }
        }

        // 👉 fallback nếu null
        if (shipData == null)
        {
            Debug.LogWarning("Load ship fail → dùng Ship_Yellow");
            shipData = Resources.Load<ShipData>("Ships/Ship_Yellow");
        }
    }

    // SAVE
    public static void Save()
    {
        SaveData data = new SaveData();

        data.highScore = highScore;

        data.shipName = shipData != null ? shipData.name : "Ship_Yellow";

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }
}