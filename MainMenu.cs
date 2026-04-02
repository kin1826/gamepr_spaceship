using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    public GameObject guidePanel;
    public CanvasGroup guidePanelCanvas;
    public GameObject selectShipPanel;
    public CanvasGroup selectShipPanelCanvas;
    
    public TextMeshProUGUI highScoreText;
    
    public Image selectShipImage;
    
    public int highScore = 0;

    // public GameData data;

    void Start()
    {
        
        LoadGame();
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
        AnimPanel(guidePanel, guidePanelCanvas);
    }

    public void CloseGuide()
    {
        guidePanel.SetActive(false);
    }
    
    private void LoadGame()
    {
        GameData.Load();
        selectShipImage.sprite = GameData.shipData.levelSprites[4];

        highScore = GameData.highScore;
        highScoreText.text = "Highest point: " + highScore;
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

    public void OpenSelectShip()
    {
        selectShipPanel.SetActive(true);
        AnimPanel(selectShipPanel, selectShipPanelCanvas);
    }
    public void CloseSelectShip()
    {
        selectShipPanel.SetActive(false);
        SelectShip();
    }

    public void SelectShip()
    {
        ShipData ship = GameData.shipData;

        selectShipImage.sprite = ship.levelSprites[
            ship.levelSprites.Length - 1
        ];

    }
}