using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public static int countUnlockedLevels = 1;

    [SerializeField] private Button[] _levelButtons;

    private void Awake()
    {
        for (int i = 0; i < countUnlockedLevels; i++)
            _levelButtons[i].interactable = true;
    }

    public static void UnlockNextLevel()
    {
        countUnlockedLevels++;
    }

    public void OnBack()
    {
        SceneManager.LoadScene(nameof(MainMenu));
    }

    public void OnClick(int index)
    {
        SceneManager.LoadScene(index);
    }
}
