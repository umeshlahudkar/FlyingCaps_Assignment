using UnityEngine;
using TMPro;
using Shooter.Global;
using Shooter.Event;

namespace Shooter.Level
{
    public class LevelManager : GenericSingleton<LevelManager>
    {
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private string[] levelNames;
        private int level;
        private int scoreToIncrementLevel;

        private void Start()
        {
            if (GetLevelStatus(levelNames[0]) == LevelStatus.Locked)
            {
                SetLevelStatus(levelNames[0], LevelStatus.Unlocked);
            }

            level = PlayerPrefs.GetInt("SelectedLevel");
            scoreToIncrementLevel = 50 * level;
            DisplayLevel();
        }

        public void CheckForLevelComplete(int score)
        {
            if (score >= scoreToIncrementLevel)
            {
                MarkLevelComplet(level);
                EventService.Instance.InvokeOnLevelCompleteEvent();
            }
        }

        public void UpdateLevel()
        {
            level++;
            DisplayLevel();
            scoreToIncrementLevel = 50 * level;
        }

        public void MarkLevelComplet(int level)
        {
            if (GetLevelStatus(levelNames[level - 1]) == LevelStatus.Unlocked)
            {
                SetLevelStatus(levelNames[level - 1], LevelStatus.Complete);
                UnlockedNextLevel(level);
            }
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
            if (levelNumber > levelNames.Length)
            {
                return null;
            }

            return levelNames[levelNumber];
        }

        private void DisplayLevel()
        {
            if (levelText != null)
            {
                levelText.text = level.ToString();
            }
        }
    }

    public enum LevelStatus
    {
        Locked,
        Unlocked,
        Complete
    }
}
