using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Shooter.Level;
using Shooter.Event;

namespace Shooter.UI
{
    public class GameSceneUIController : MonoBehaviour
    {
        [Header("Level Fail/Complete Display")]
        [SerializeField] private GameObject levelInfoDisplay;
        [SerializeField] private TextMeshProUGUI displayTitleText;
        [SerializeField] private TextMeshProUGUI displayLevelText;
        [SerializeField] private TextMeshProUGUI displayScoreText;
        [SerializeField] private TextMeshProUGUI displayHighScoreText;
        [SerializeField] private Button replayButton;
        [SerializeField] private Button nextButton;

        [Header("Score Display")]
        [SerializeField] private GameObject scoreDisplay;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI highScoreText;

        [Header("Button")]
        [SerializeField] private Button pauseButton;

        [Header("Game Pause Display")]
        [SerializeField] private GameObject gamePauseDisplay;


        private void Start()
        {
            levelInfoDisplay.SetActive(false);
            EventService.Instance.OnLevelFailed += EnableLevelFailedDisplay;
            EventService.Instance.OnLevelComplete += EnableLevelCompleteDisplay;
        }

        public void EnableLevelFailedDisplay()
        {
            scoreDisplay.SetActive(false);
            nextButton.gameObject.SetActive(false);
            replayButton.gameObject.SetActive(true);
            displayTitleText.text = "Level Failed";
            displayLevelText.text = levelText.text;
            displayScoreText.text = scoreText.text;
            displayHighScoreText.text = highScoreText.text;
            levelInfoDisplay.SetActive(true);
        }

        public void EnableLevelCompleteDisplay()
        {
            scoreDisplay.SetActive(false);
            nextButton.gameObject.SetActive(true);
            replayButton.gameObject.SetActive(false);
            displayTitleText.text = "Level Complete";
            displayLevelText.text = levelText.text;
            displayScoreText.text = scoreText.text;
            displayHighScoreText.text = highScoreText.text;
            levelInfoDisplay.SetActive(true);
        }

        public void OnPauseButtonClicked()
        {
            Time.timeScale = 0;
            pauseButton.interactable = false;
            gamePauseDisplay.SetActive(true);
        }

        public void OnResumeButtonClick()
        {
            Time.timeScale = 1;
            pauseButton.interactable = true;
            gamePauseDisplay.SetActive(false);
        }

        public void OnMenuButtonClick()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);

        }

        public void OnReplayButtonClick()
        {
            levelInfoDisplay.SetActive(false);
            scoreDisplay.SetActive(true);
            EventService.Instance.InvokeOnReplayButtonClickEvent();
        }

        public void OnNextButtonClick()
        {
            levelInfoDisplay.SetActive(false);
            scoreDisplay.SetActive(true);
            LevelManager.Instance.UpdateLevel();
            EventService.Instance.InvokeOnNewLevelStartEvent();
        }

        private void OnDisable()
        {
            EventService.Instance.OnLevelFailed -= EnableLevelFailedDisplay;
            EventService.Instance.OnLevelComplete -= EnableLevelCompleteDisplay;
        }
    }

}
