using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public GameObject gameOverPanel;
    public GameObject gamePausePanel;

    public int score = 0;
    public int currentLevel = 1;
    public string currentSkin = "1";
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        AudioManager.instance.PlayMusic(AudioManager.instance.gameMusic);
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
    
    public void GameOver()
    {
        Debug.Log("Game Over");
        gameOverPanel.SetActive(true);
        
        SaveGame();
        Time.timeScale = 0f; // pause game
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        gamePausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        gamePausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void SaveGame()
    {
        GameData oldData = SaveSystem.Load();

        if (score > oldData.highScore)
        {
            oldData.highScore = score;
        }
        
        oldData.currentScore = score;
        oldData.playerSkin = currentSkin;
        oldData.level = currentLevel;
        
        SaveSystem.Save(oldData);
    }
}