using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayHints : MonoBehaviour
{
    public static int currentLevel = 1;
    public Text hintText;

    /* All hint texts for every level in the campaign */
    private readonly string[] hintTexts = {  "This won't end well for you!",
                            "Watch where you're going!",
                            "Move it or lose it!",
                            "You are quite outnumbered!",
                            "Grab the coins!",
                            "Your enemies are highly coordinated...",
                            "Even with checkpoints you\nhave no chance at all!",
                            "Around and around they go!",
                            "This is all quite pointless, really...",
                            "This level will be your end!",
                            "You might be proud of yourself\n but that feeling won't last long.",
                            "Make sure you get that key!"
    };

    void Start()
    {
        hintText.text = hintTexts[currentLevel - 1];

        /*switch(currentLevel)
        {
            case 1:
                hintText.text = "This won't end well for you!";
                break;

            case 2:
                hintText.text = "Watch where you're going!";
                break;

            case 3:
                hintText.text = "Move it or lose it!";
                break;

            case 4:
                hintText.text = "You are quite outnumbered!";
                break;

            case 5:
                hintText.text = "Grab the coins!";
                break;

            case 6:
                hintText.text = "Your enemies are highly coordinated...";
                break;

            case 7:
                hintText.text = "Even with checkpoints you\nhave no chance at all!";
                break;

            case 8:
                hintText.text = "Around and around they go!";
                break;

            case 9:
                hintText.text = "This is all quite pointless, really...";
                break;
        }*/
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }

}
