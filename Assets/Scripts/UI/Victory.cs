using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public void OnClickLevelsOfList()
    {
        SceneManager.LoadScene(nameof(LevelSelection));
    }

    public void OnClickMenu()
    {
        SceneManager.LoadScene(nameof(MainMenu));
    }
}
