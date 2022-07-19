using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _gameAfterPauseText;
    [SerializeField] private int _currentSecond;

    [SerializeField] private Button _pauseButton;
    public void StartGameAfterPause()
    {
        _gameAfterPauseText.text = _currentSecond.ToString();
        StartCoroutine(WaitForStartGame());
        StartCoroutine(DisplayText());
        _gameAfterPauseText.alpha = 1;
        _pauseButton.interactable = false;
    }
    private IEnumerator WaitForStartGame()
    {
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1;
    }
    private IEnumerator DisplayText()
    {
        while(_currentSecond != 0)
        {
            yield return new WaitForSecondsRealtime(1f);
            _currentSecond--;
            _gameAfterPauseText.text = _currentSecond.ToString();
        }

        _gameAfterPauseText.alpha = 0;
        _currentSecond = 3;
        _pauseButton.interactable = true;
    }
}
