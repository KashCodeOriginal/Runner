using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePaused : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
