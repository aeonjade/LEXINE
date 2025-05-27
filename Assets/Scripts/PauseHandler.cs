using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseHandler : MonoBehaviour
{
    public CanvasGroup pauseMenuUI;
    public CanvasGroup gameplayUI;

    private bool isPaused = false;

    void Start()
    {
        VolumeSettings.VolumeSettingsInstance.VolumeInit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.alpha = 0f;
        pauseMenuUI.interactable = false;
        pauseMenuUI.blocksRaycasts = false;
        Time.timeScale = 1f;
        isPaused = false;

        if (gameplayUI != null)
        {
            gameplayUI.interactable = true;
            gameplayUI.blocksRaycasts = true;
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.alpha = 1f;
        pauseMenuUI.interactable = true;
        pauseMenuUI.blocksRaycasts = true;
        Time.timeScale = 0f;
        isPaused = true;

        if (gameplayUI != null)
        {
            gameplayUI.interactable = false;
            gameplayUI.blocksRaycasts = false;
        }
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        Destroy(GameObject.FindGameObjectWithTag("UIRoot"));
        SceneManager.LoadScene("MainMenu");
    }
}
