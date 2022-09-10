using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : GenericSingleton<LevelManager>
{
    [SerializeField] private TextMeshProUGUI levelInfoText;
    [SerializeField] private string[] levelNames;


    private void Start()
    {
        SetLevelStatus(levelNames[0], LevelStatus.Unlocked);
    }

    public void MarkLevelComplet(int level)
    {
        SetLevelStatus(levelNames[level - 1], LevelStatus.Complete);
        UnlockedNextLevel(level);
    }

    private void UnlockedNextLevel(int level)
    {
        SetLevelStatus(levelNames[level], LevelStatus.Unlocked);
    }

    public LevelStatus GetLevelStatus(string levelName)
    {
        LevelStatus status = (LevelStatus)PlayerPrefs.GetInt(levelName, 0);
        return status;
    }

    private void SetLevelStatus(string levelName, LevelStatus status)
    {
        PlayerPrefs.SetInt(levelName, (int)status);
    }

    public string GetLevelName(int levelNumber)
    {
        if(levelNumber > levelNames.Length)
        {
            return null;
        }

        return levelNames[levelNumber - 1];
    }
}

public enum LevelStatus
{
    Locked,
    Unlocked,
    Complete
}
