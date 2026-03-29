using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public GameObject gameOverPanel;
    public CanvasGroup gameOverPanelCanvas;
    public GameObject gamePausePanel;
    public CanvasGroup gamePausePanelCanvas;
    public GameObject gameWinPanel;
    public CanvasGroup winPanelCanvas;

    //Score
    public int score = 0;
    public bool isHighest = false;
    //Save
    public int currentLevel = 1;
    public string currentSkin = "1";
    
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreGameOverText;
    
    //Process
    public int currentProcess = 0;
    public int maxProcess = GameConfig.Process.maxProcess;
    public Slider slider;
    [SerializeField] private Image processFillImage;
    [SerializeField] private Sprite[] processStageSprites = new Sprite[5];
    

    void Awake()
    {
        instance = this;
        CacheProcessFillImage();
    }

    void Start()
    {
        AudioManager.instance.PlayMusic(AudioManager.instance.gameMusic);
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;

        float processRatio = maxProcess > 0 ? (float)currentProcess / maxProcess : 0f;
        slider.value = processRatio;
        UpdateProcessStageSprite(processRatio);
    }
    
    public void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0f; // pause game
        StartCoroutine(ShowWinPanelAfterDelay());
        
        AudioManager.instance.PlaySFX(AudioManager.instance.gameOverSound);
        
        SaveGame();
        if (isHighest)
        {
            scoreGameOverText.text = "New Highest Score: " + score;
        }
        else
        {
            scoreGameOverText.text = "Score: " + score;
        }
        
        gameOverPanel.SetActive(true);
        
        instance.AnimPanel(gameOverPanel, gameOverPanelCanvas);
        scoreText.enabled = false;
        
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
        instance.AnimPanel(gamePausePanel, gamePausePanelCanvas);
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
            isHighest = true;
            oldData.highScore = score;
        }
        
        oldData.currentScore = score;
        oldData.playerSkin = currentSkin;
        oldData.level = currentLevel;
        
        SaveSystem.Save(oldData);
    }
    
    public void AddProcess(int amount)
    {
        currentProcess += amount;

        if (currentProcess >= maxProcess)
        {
            currentProcess = maxProcess;
            instance.Win();
        }
            
        
        UpdateUI();
    }

    private void CacheProcessFillImage()
    {
        if (processFillImage != null || slider == null || slider.fillRect == null)
        {
            return;
        }

        processFillImage = slider.fillRect.GetComponent<Image>();
    }

    private void UpdateProcessStageSprite(float processRatio)
    {
        CacheProcessFillImage();

        if (processFillImage == null || processStageSprites == null || processStageSprites.Length == 0)
        {
            return;
        }

        int configuredStageCount = 0;
        for (int i = 0; i < processStageSprites.Length; i++)
        {
            if (processStageSprites[i] != null)
            {
                configuredStageCount++;
            }
        }

        if (configuredStageCount == 0)
        {
            return;
        }

        int stageIndex = Mathf.FloorToInt(Mathf.Clamp01(processRatio) * configuredStageCount);
        stageIndex = Mathf.Clamp(stageIndex, 0, configuredStageCount - 1);

        Sprite targetSprite = null;
        int currentConfiguredIndex = -1;
        for (int i = 0; i < processStageSprites.Length; i++)
        {
            if (processStageSprites[i] == null)
            {
                continue;
            }

            currentConfiguredIndex++;
            if (currentConfiguredIndex == stageIndex)
            {
                targetSprite = processStageSprites[i];
                break;
            }
        }

        if (targetSprite != null && processFillImage.sprite != targetSprite)
        {
            processFillImage.sprite = targetSprite;
            processFillImage.SetAllDirty();
        }
    }

    public void Win()
    {
        Time.timeScale = 0f;
        StartCoroutine(ShowWinPanelAfterDelay());
        
        AudioManager.instance.PlaySFX(AudioManager.instance.winSound);
        AudioManager.instance.PlaySFX(AudioManager.instance.winVoice);
        
        gameWinPanel.SetActive(true);
        instance.AnimPanel(gameWinPanel, winPanelCanvas);
    }

    private System.Collections.IEnumerator ShowWinPanelAfterDelay()
    {
        yield return new WaitForSecondsRealtime(1.5f);
    }
    
    public void AnimPanel(GameObject panel, CanvasGroup canvasGroup)
    {
        // reset trạng thái ban đầu
        panel.transform.localScale = Vector3.zero;
        canvasGroup.alpha = 0;

        // scale pop (nảy nảy)
        panel.transform
            .DOScale(Vector3.one, 0.4f)
            .SetEase(Ease.OutBack)
            .SetUpdate(true); // quan trọng khi timeScale = 0

        // fade in
        canvasGroup
            .DOFade(1, 0.3f)
            .SetUpdate(true);
    }
}
