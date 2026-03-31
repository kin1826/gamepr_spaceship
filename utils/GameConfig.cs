using UnityEngine;

public static class GameConfig
{
    //Player Speed
    public static class Player
    {
        public static float[] speed = { 3f, 3.3f, 3.6f, 4f, 4.3f };
    }
    
    //Damage Bullet By Level
    public static class Bullet
    {
        public static int[] damage = { 1, 2, 3, 4, 5 };
        public static int[] speed = { 10, 12, 15, 16, 20 };
    }
    
    //Button setting
    public static class UI
    {
        public static Vector3 hoverScaleBtn = new Vector3(1.05f, 1.05f, 1.05f);
        public static Vector3 pressedScaleBtn = new Vector3(0.85f, 0.85f, 0.85f);
    }
    
    //Process setting
    public static class Process
    {
        public static int maxProcess = 40;
    }
    
    public static class Shields
    {
        public static float duration = 3f;
        public static float blinkTime = 0.5f;
    }
    
}
