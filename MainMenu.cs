using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject guidePanel;
    
    public TextMeshProUGUI highScoreText;
    
    public int highScore = 0;

    void Start()
    {
        LoadGame();
        guidePanel.SetActive(false);
        AudioManager.instance.PlayMusic(AudioManager.instance.menuMusic);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene"); // tên scene game
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToggleSound()
    {
        AudioListener.volume = AudioListener.volume == 1 ? 0 : 1;
    }

    public void OpenGuide()
    {
        guidePanel.SetActive(true);
    }

    public void CloseGuide()
    {
        guidePanel.SetActive(false);
    }
    
    private void LoadGame()
    {
        GameData data = SaveSystem.Load();

        if (data != null)
        {
            highScore = data.highScore;
            int currentScore = data.currentScore;
            string skin = data.playerSkin;
                   
            highScoreText.text = "Highest point: " + highScore;
        }

        
    }
}