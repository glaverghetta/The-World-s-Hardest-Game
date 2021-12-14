using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // When player enters End asset
        if(collision.gameObject.name.Equals("Player"))
        {
            // Finish level if no coins are left
            if (GameObject.FindGameObjectsWithTag("Coin").Length == 0)
            {
                DisplayHints.currentLevel++;
                int tipsSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
                SceneManager.LoadScene(tipsSceneIndex);
            }
        }
    }

}
