using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [SerializeField] private GameObject LevelParent;
    [SerializeField] private TextMeshProUGUI LevelsText;
    [SerializeField] private bool SelectedLevel;
    [SerializeField] private int WhichLevel;
    private int numberOfLevels;

    private void Awake()
    {
        if (!instance)
            instance = this;

    }
    private void Start()
    {
        for (int i = 0; i < LevelParent.transform.childCount; i++)
        {
            LevelParent.transform.GetChild(i).gameObject.SetActive(false);
        }
        PrintLevelCount();
    }
    public void PrintLevelCount()
    {
        int levelTextCount = PlayerPrefs.GetInt("LevelCount") + 1;
        LevelsText.text = "LEVEL " + levelTextCount;
    }
    public void OpenLevel()
    {
        if (SelectedLevel)
            numberOfLevels = WhichLevel;
        else
            SetPlayerPrefs();

        print("openlevel");
        LevelParent.transform.GetChild(numberOfLevels).gameObject.SetActive(true);
    }

    private void SetPlayerPrefs()
    {
        if (LevelParent.transform.childCount <= PlayerPrefs.GetInt("nextLevel"))
        {
            PlayerPrefs.SetInt("nextLevel", 0);
            numberOfLevels = PlayerPrefs.GetInt("nextLevel");
        }
        else
            numberOfLevels = PlayerPrefs.GetInt("nextLevel");
    }

    public void NextLevel()//win
    {
        PlayerPrefs.SetInt("LevelCount", PlayerPrefs.GetInt("LevelCount") + 1);
        PlayerPrefs.SetInt("nextLevel", PlayerPrefs.GetInt("nextLevel") + 1);
    }

    public void RestartLevel()//Gameover
    {
        PlayerPrefs.SetInt("LevelCount", PlayerPrefs.GetInt("LevelCount"));
        PlayerPrefs.SetInt("nextLevel", PlayerPrefs.GetInt("nextLevel"));
    }
}
