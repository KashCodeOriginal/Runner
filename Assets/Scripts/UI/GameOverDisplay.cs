using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverDisplay : MonoBehaviour
{
    public UnityAction PlayerDied;

    [SerializeField] private Player _player;
    [SerializeField] private PlayerInput _playerInput;

    [SerializeField] private GameObject _gameOverPanel;
    
    [SerializeField] private GameObject _healthDeplay;

    [SerializeField] private Spawner spawner;

    [SerializeField] private Transform _enemiesList;
    [SerializeField] private Transform _coinsList;
    [SerializeField] private Transform _longObjList;

    [SerializeField] private Button _restartButton;
    
    private void Start()
    {
        _gameOverPanel.SetActive(false);
    }
    private void ControlAllEnemies(bool enableObjectsMoving, Transform list)
    {
        foreach (Transform obj in list)
        {
            if (obj.gameObject.activeSelf == true && obj.gameObject.GetComponent<Enemy>() == true)
            {
                obj.gameObject.GetComponent<EnemyMover>().enabled = enableObjectsMoving;
            }
            else if (obj.gameObject.activeSelf == true && obj.gameObject.GetComponent<Coin>() == true)
            {
                obj.gameObject.GetComponent<CoinMover>().enabled = enableObjectsMoving;
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
        spawner.enabled = false;
        
        _healthDeplay.SetActive(false);
        
        _gameOverPanel.SetActive(true);
        
        PlayerDied?.Invoke();

        ControlAllEnemies(false,_enemiesList);
        ControlAllEnemies(false,_coinsList);
        ControlAllEnemies(false,_longObjList);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
