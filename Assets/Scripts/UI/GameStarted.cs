using UnityEngine;
using UnityEngine.Events;

public class GameStarted : MonoBehaviour
{
    public UnityAction GameIsStarted;
    
    [SerializeField] private Animator _playerAnimation;
    [SerializeField] private Transform _playerTransform;

    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private ScoreDisplay _scoreDisplay;

    public void StartGame()
    {
        PlayerStartAnimation();
        PlayerMovingStart();
        EnemyMovingStart();
        GameIsStarted?.Invoke();
    }
 
    private void PlayerStartAnimation()
    {
        _playerTransform.rotation = new Quaternion(0, 0, 0,0);
        _playerAnimation.SetBool("GameStarted",true);
        _playerTransform.position = new Vector3(0, 0.25f, -8.5f);
    }

    private void PlayerMovingStart()
    {
        _playerInput.enabled = true;
    }

    private void EnemyMovingStart()
    {
        _spawner.enabled = true;
    }
}
