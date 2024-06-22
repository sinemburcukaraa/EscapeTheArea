using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject joysCanvas;
    public static UIManager instance;
    [SerializeField] private GameObject winPanel, failPanel, startPanel, gamePanel;
    private void Awake()
    {
        instance = this;
    }
    public void WinPanel(bool control)
    {
        winPanel.SetActive(control);
        joysCanvas.SetActive(!control);
    }
    public void StartPanel(bool control)
    {
        startPanel.SetActive(control);

    }
    public void GamePanel(bool control)
    {
        gamePanel.SetActive(control);
        joysCanvas.SetActive(control);
    }
    public void FailPanel(bool control)
    {
        failPanel.SetActive(control);
        joysCanvas.SetActive(!control);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}
