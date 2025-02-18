using System;
using TMPro;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    
    [SerializeField]
    private TMP_Text timerText;

    private SceneChangeScript sceneChangeScript;
    
    public float timer;

    private void Awake()
    {
        sceneChangeScript = FindObjectOfType<SceneChangeScript>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        timerText.text = string.Format(
            "{0:00}:{1:00}",
            Mathf.FloorToInt(timer / 60),
            Mathf.FloorToInt(timer % 60)
        );
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitToMain()
    {
        Time.timeScale = 1f;
        sceneChangeScript.ReturnToMain();
    }
}
