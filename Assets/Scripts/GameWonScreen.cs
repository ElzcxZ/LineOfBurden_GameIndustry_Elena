using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWonScreen : MonoBehaviour
{
    public void GoToMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
