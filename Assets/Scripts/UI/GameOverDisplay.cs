using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInput _playerInput;

    [SerializeField] private GameObject _gameOverPanel;

    [SerializeField] private EnemySpawner _enemySpawner;

    [SerializeField] private Transform _enemiesList;

    [SerializeField] private Button _restartButton;
    
    private void Start()
    {
        _gameOverPanel.SetActive(false);
    }
    private void ControlAllEnemies(bool enableEnemyMoving)
    {
        foreach (Transform enemy in _enemiesList)
        {
            if (enemy.gameObject.activeSelf == true)
            {
                enemy.gameObject.GetComponent<EnemyMover>().enabled = enableEnemyMoving;
            }
        }
    }
    private void OnEnable()
    {
        _player.Died += OnPlayerDied;
        _restartButton.onClick.AddListener(RestartGame);
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDied;
        _restartButton.onClick.RemoveListener(RestartGame);
    }

    private void OnPlayerDied()
    {
        _playerInput.enabled = false;
        _enemySpawner.enabled = false;
        _gameOverPanel.SetActive(true);

        ControlAllEnemies(false);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
