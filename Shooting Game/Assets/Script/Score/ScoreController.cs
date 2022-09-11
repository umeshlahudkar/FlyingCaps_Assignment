using UnityEngine;
using TMPro;
using Shooter.Event;
using Shooter.Level;

namespace Shooter.Score
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI highScoreText;

        private int score = 0;
        private int highScore;
        private string HighScore = "HighScore";

        private void OnEnable()
        {
            EventService.Instance.OnEnemyKilled += UpdateScore;
            EventService.Instance.OnReplayButtonClick += ResetScore;
        }

        private void Start()
        {
            highScore = PlayerPrefs.GetInt(HighScore, 0);
            DisplayScore();
            DisplayHighScore();
        }

        private void ResetScore()
        {
            score = 0;
            DisplayScore();
        }

        private void UpdateScore()
        {
            score += 10;
            DisplayScore();

            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt(HighScore, highScore);
                DisplayHighScore();
            }

            LevelManager.Instance.CheckForLevelComplete(score);
        }

        private void DisplayScore()
        {
            scoreText.text = score.ToString();
        }

        private void DisplayHighScore()
        {
            highScoreText.text = highScore.ToString();
        }

        private void OnDisable()
        {
            EventService.Instance.OnEnemyKilled -= UpdateScore;
            EventService.Instance.OnReplayButtonClick -= ResetScore;
        }
    }

}
