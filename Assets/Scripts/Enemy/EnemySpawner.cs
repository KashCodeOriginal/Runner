using UnityEngine;

public class EnemySpawner : ObjectsPool
{
    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private float _minTimeBetweenSpawn;
    [SerializeField] private float _decreaseStep;

    [SerializeField] private GameValuesChanger gameValuesChanger;

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
        gameValuesChanger.TryDecreaseValue(ref _timeBetweenSpawn, _minTimeBetweenSpawn,_decreaseStep);
    }

    private void SetEnemy(GameObject enemy)
    {
        enemy.SetActive(true);
        _randomPositionMover.MoveToPosition(enemy);
    }
}
 