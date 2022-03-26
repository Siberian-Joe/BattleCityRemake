using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnClickStartGame()
    {
        SceneManager.LoadScene(nameof(LevelSelection));
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
