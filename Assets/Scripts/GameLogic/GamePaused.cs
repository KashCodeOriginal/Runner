using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePaused : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void UnpauseGame()
    {
        _timer.StartGameAfterPause();
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
