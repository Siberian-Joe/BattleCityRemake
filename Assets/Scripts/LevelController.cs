using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.Victory += OnVictory;
        EventManager.Defeat += OnDefeat;
    }

    private void OnDisable()
    {
        EventManager.Victory -= OnVictory;
        EventManager.Defeat -= OnDefeat;
    }

    private void OnVictory()
    {
        if(SceneManager.GetActiveScene().buildIndex == LevelSelection.countUnlockedLevels)
            LevelSelection.UnlockNextLevel();

        SceneManager.LoadScene(nameof(Victory));
    }

    private void OnDefeat()
    {
        SceneManager.LoadScene(nameof(Defeat));
    }
}
