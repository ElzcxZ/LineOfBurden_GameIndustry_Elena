using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void GoToMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
