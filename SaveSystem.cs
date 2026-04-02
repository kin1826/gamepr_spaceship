using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static string path = Application.persistentDataPath + "/data/game_save.json";

    public static void Save(GameData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
        Debug.Log("Saved to: " + path);
    }

    // public static void Load()
    // {
    //     if (File.Exists(path))
    //     {
    //         string json = File.ReadAllText(path);
    //         return JsonUtility.FromJson<GameData>(json);
    //     }
    //     
    //     GameData.
    //     
    //
    //     return new GameData(); // default nếu chưa có save
    // }
}