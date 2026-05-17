using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class TitleScreen : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Game");
    }
}
