using UnityEngine;

public class Spawner : ObjectsPool
{
    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private float _timeBetweenSpawn;

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
        gameValuesChanger.TryDecreaseEnemiesValue(ref _timeBetweenSpawn);
    }

    private void SetEnemy(GameObject enemy)
    {
        enemy.SetActive(true);
        _randomPositionMover.MoveToPosition(enemy);
    }
}
 