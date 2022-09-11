using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
        selectedLevelNumber = level - 1;
        selectedLevelName = LevelManager.Instance.GetLevelName(level);
        levelStatus = LevelManager.Instance.GetLevelStatus(selectedLevelName);

        levelInfoText.text = selectedLevelName + " -> " + levelStatus;
    }

    public void OnStartButtonClick()
    {
        if(levelStatus == LevelStatus.Unlocked)
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
