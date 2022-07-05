using UnityEngine;

public class GameStarted : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimation;
    [SerializeField] private Transform _playerTransform;

    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private EnemySpawner _spawner;

    public void StartGame()
    {
        PlayerStartAnimation();
        PlayerMovingStart();
        EnemyMovingStart();
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
