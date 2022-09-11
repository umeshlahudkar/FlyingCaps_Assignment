using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Shooter.Level;

namespace Shooter.UI
{
    public class LobbySceneUIController : MonoBehaviour
    {
        [SerializeField] private GameObject levelSelectionPanel;
        [SerializeField] private GameObject mainUIPanel;
        [SerializeField] private TextMeshProUGUI levelInfoText;

        private string selectedLevelName;
        private int selectedLevelNumber;
        private LevelStatus levelStatus;

        private void Start()
        {
            mainUIPanel.SetActive(true);
            levelSelectionPanel.SetActive(false);
        }

        public void OnPlayButtonClicked()
        {
            levelSelectionPanel.SetActive(true);
            mainUIPanel.SetActive(false);
        }

        public void OnLevelButtonClicked(int level)
        {
            selectedLevelNumber = level;
            selectedLevelName = LevelManager.Instance.GetLevelName(level - 1);
            levelStatus = LevelManager.Instance.GetLevelStatus(selectedLevelName);

            levelInfoText.text = selectedLevelName + " -> " + levelStatus;
        }

        public void OnStartButtonClick()
        {
            if (levelStatus != LevelStatus.Locked)
            {
                PlayerPrefs.SetInt("SelectedLevel", selectedLevelNumber);
                SceneManager.LoadScene(1);
            }
        }

        public void OnQuitButtonClicked()
        {
            Application.Quit();
        }
    }
}
