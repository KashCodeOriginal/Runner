using UnityEngine;

public class Spawner : ObjectsPool
{
    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private float _timeBetweenSpawn;

    [SerializeField] private GameValuesChange _gameValuesChange;

    private float _passedTimeBetweenEnemies = 0;
    
    private RandomPositionMover _randomPositionMover;

    private void Start()
    {
        _randomPositionMover = gameObject.GetComponent<RandomPositionMover>();
        Initialize(_enemyPrefab);
    }

    private void Update()
    {
        _passedTimeBetweenEnemies += Time.deltaTime;

        if (_passedTimeBetweenEnemies >= _timeBetweenSpawn)
        {
            if (TryGetEnemy(out GameObject enemy))
            {
                _passedTimeBetweenEnemies = 0;
                SetEnemy(enemy);
            }
        }
        _gameValuesChange.TryDecreaseValue(ref _timeBetweenSpawn);
    }

    private void SetEnemy(GameObject enemy)
    {
        enemy.SetActive(true);
        _randomPositionMover.MoveToGeneratedPosition(enemy);
    }
    
}
 