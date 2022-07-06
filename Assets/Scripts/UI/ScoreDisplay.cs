using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _highscore;

    [SerializeField] private float _timeBetweenAddingScore;
    [SerializeField] private float _minTimeBetweenAddingScore;
    [SerializeField] private float _decreaseStep;
    [SerializeField] private int _scorePerSeconds;

    [SerializeField] private GameStarted _gameStarted;

    [SerializeField] private GameOverDisplay _gameOverDisplay;

    [SerializeField] private GameValuesChanger _gameValuesChanger;

    private float _passedTimeBetweenAddingScore;

    private int _currentScore;
    private int _currentHighscore;

    private bool _isScoreStopped;
    
    private void Start()
    {
        _score.text = "0";
        _currentScore = 0;
        LoadScore();
        _highscore.text = _currentHighscore.ToString();
        _isScoreStopped = true;
    }

    private void Update()
    {
        _passedTimeBetweenAddingScore += Time.deltaTime;
        if (_passedTimeBetweenAddingScore >= _timeBetweenAddingScore && !_isScoreStopped)
        {
            AddScore();
            _passedTimeBetweenAddingScore = 0;
        }

        if (!_isScoreStopped)
        {
            _gameValuesChanger.TryDecreaseValue(ref _timeBetweenAddingScore, _minTimeBetweenAddingScore, _decreaseStep);
        }
    }

    private void AddScore()
    {
        _currentScore += _scorePerSeconds;
        _score.text = _currentScore.ToString();

        if (_currentScore >= _currentHighscore)
        {
            _currentHighscore = _currentScore;
            _highscore.text = _currentHighscore.ToString();
            SaveScore();
        }
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt("highscore", _currentHighscore);
    }
    private void LoadScore()
    {
        _currentHighscore = PlayerPrefs.GetInt("highscore");
    }

    private void OnEnable()
    {
        _gameOverDisplay.PlayerDied += ScoreStop;
        _gameStarted.GameIsStarted += ScoreResume;
    }
    private void OnDisable()
    {
        _gameOverDisplay.PlayerDied -= ScoreStop;
        _gameStarted.GameIsStarted -= ScoreResume;
    }

    private void ScoreStop()
    {
        _isScoreStopped = true;
    }
    private void ScoreResume()
    {
        _isScoreStopped = false;
    }
}
