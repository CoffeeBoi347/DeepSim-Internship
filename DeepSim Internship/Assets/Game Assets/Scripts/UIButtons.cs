using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public GameObject pauseButtonSettings;
    public void PauseButton()
    {
        var pauseObjSettings = pauseButtonSettings.GetComponent<CanvasGroup>();
        pauseObjSettings.alpha = 1;
        pauseObjSettings.interactable = true;
        pauseObjSettings.blocksRaycasts = true;
        Time.timeScale = 0f;
    }

    public void ResumeButton()
    {
        var pauseObjSettings = pauseButtonSettings.GetComponent<CanvasGroup>();
        pauseObjSettings.alpha = 0;
        pauseObjSettings.interactable = false;
        pauseObjSettings.blocksRaycasts = false;
        Time.timeScale = 1f;
    }

    public void RespawnButton()
    {
        SceneManager.LoadScene(0);
    }
}