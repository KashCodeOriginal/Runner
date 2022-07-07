using UnityEngine;

public class Spawner : ObjectsPool
{
    [SerializeField] private GameObject _coinsPrefabs;
    [SerializeField] private GameObject[] _objectPrefabs;

    [SerializeField] private float _timeBetweenEnemiesSpawn;
    [SerializeField] private float _minTimeBetweenEnemiesSpawn;
    [SerializeField] private float _decreaseStep;
    
    [SerializeField] private float _timeBetweenCoinsSpawn;
    
    [SerializeField] private GameValuesChanger gameValuesChanger;
    [SerializeField] private RandomPositionMover _randomPositionMover;
    
    private float _passedTimeBetweenEnemiesObjects = 0;
    private float _passedTimeBetweenCoinsObjects = 0;

    private void Start()
    {
        _randomPositionMover = gameObject.GetComponent<RandomPositionMover>();
        Initialize(_objectPrefabs);
        Initialize(_coinsPrefabs);
    }

    private void Update()
    {
        _passedTimeBetweenEnemiesObjects += Time.deltaTime;
        _passedTimeBetweenCoinsObjects += Time.deltaTime;

        if (_passedTimeBetweenEnemiesObjects >= _timeBetweenEnemiesSpawn)
        {
            if (TryGetObject(out GameObject obj))
            {
                _passedTimeBetweenEnemiesObjects = 0;
                SetObject(obj);
            }
        }
        else if (_passedTimeBetweenCoinsObjects >= _timeBetweenCoinsSpawn)
        {
            if (TryGetCoinObject(out GameObject obj))
            {
                _passedTimeBetweenCoinsObjects = 0;
                SetObject(obj);
            }
        }
        gameValuesChanger.TryDecreaseValue(ref _timeBetweenEnemiesSpawn, _minTimeBetweenEnemiesSpawn,_decreaseStep);
    }

    private void SetObject(GameObject obj)
    {
        obj.SetActive(true);
        _randomPositionMover.MoveObjectToPosition(obj);
    }
}
 