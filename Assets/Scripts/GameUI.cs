using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    Player player;

    public Text levelText;
    public Text deathText;

    void Start()
    {
        player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.OnPlayerDeath += UpdateDeaths;
        }

        deathText.text = "Total deaths: " + Player.totalDeaths;
        if (levelText != null)
        {
            levelText.text = "Level " + DisplayHints.currentLevel;
        }
    }

    void UpdateDeaths()
    {
        deathText.text = "Total deaths: " + Player.totalDeaths;
    }

    /* Script to run when the Campaign button is clicked */
    public void CampaignButtonClick()
    {
        // The Tips and Hints scene should always be the last scene in Build Settings
        int tipsSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        SceneManager.LoadScene(tipsSceneIndex);
    }

    // Go back to main menu
    public void MenuClick()
    {
        DisplayHints.currentLevel = 1;
        Player.totalDeaths = 0;
        SceneManager.LoadScene(0);
    }

}
