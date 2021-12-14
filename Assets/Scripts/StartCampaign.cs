using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartCampaign : MonoBehaviour
{
    /* Script to run when the Campaign button is clicked */
    public void CampaignButtonClick()
    {
        // The Tips and Hints scene should always be the last scene in Build Settings
        int tipsSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        SceneManager.LoadScene(tipsSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
