using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private enum GameState { notStarted, Started, Win, Fail }
    [SerializeField] private GameState gameState;
    [SerializeField] private bool isThereStartPanel;
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        StartPanelControl();
    }
    
    public void StartPanelControl()
    {
        if (isThereStartPanel)
            NotStarted();
        else
            Started();
    }
    private void NotStarted()
    {
        gameState = GameState.notStarted;
        UIManager.instance.StartPanel(true);
    }
    private void Started()
    {
        gameState = GameState.Started;

        UIManager.instance.StartPanel(false);
        UIManager.instance.GamePanel(true);
        LevelManager.instance.OpenLevel();

    }
    public void LevelCompleted()
    {
        gameState = GameState.Win;

        UIManager.instance.WinPanel(true);
        UIManager.instance.GamePanel(false);

        LevelManager.instance.NextLevel();
    }
    public void GameOver()
    {
        gameState = GameState.Fail;

        UIManager.instance.FailPanel(true);
        UIManager.instance.GamePanel(false);

        LevelManager.instance.RestartLevel();
    }
}
