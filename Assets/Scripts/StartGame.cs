using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Replace "GameScene" with your actual game scene name
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit(); // Works only in a built application
    }
}
