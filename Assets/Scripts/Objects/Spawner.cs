using UnityEngine;

public class Spawner : ObjectsPool
{
    [SerializeField] private GameObject _coinsPrefabs;
    [SerializeField] private GameObject[] _objectPrefabs;
    [SerializeField] private GameObject[] _longObjectPrefabs;

    [SerializeField] private float _timeBetweenEnemiesSpawn;
    [SerializeField] private float _minTimeBetweenEnemiesSpawn;
    [SerializeField] private float _decreaseStep;
    
    [SerializeField] private float _timeBetweenCoinsSpawn;
    [SerializeField] private float _minTimeBetweenCoinsSpawn;
    
    [SerializeField] private float _timeBetweenLongObjectsSpawn;
    [SerializeField] private float _minTimeBetweenLongObjectsSpawn;
    
    [SerializeField] private GameValuesChanger gameValuesChanger;
    [SerializeField] private RandomPositionMover _randomPositionMover;
    
    private float _passedTimeBetweenEnemiesObjects = 0;
    private float _passedTimeBetweenCoinsObjects = 0;
    private float _passedTimeBetweenLongObjects = 0;

    private void Start()
    {
        _randomPositionMover = gameObject.GetComponent<RandomPositionMover>();
        Initialize(_objectPrefabs, _pool, _objectsContainer);
        Initialize(_longObjectPrefabs, _longObjPool, _longObjContainer);
        Initialize(_coinsPrefabs);
    }

    private void Update()
    {
        _passedTimeBetweenEnemiesObjects += Time.deltaTime;
        _passedTimeBetweenCoinsObjects += Time.deltaTime;
        _passedTimeBetweenLongObjects += Time.deltaTime;
        
        CheckPassedTime(_passedTimeBetweenEnemiesObjects, _timeBetweenEnemiesSpawn, "enemy");
        CheckPassedTime(_passedTimeBetweenCoinsObjects, _timeBetweenCoinsSpawn, "coin");
        CheckPassedTime(_passedTimeBetweenLongObjects, _timeBetweenLongObjectsSpawn, "longObj");
        
        gameValuesChanger.TryDecreaseValue(ref _timeBetweenEnemiesSpawn, _minTimeBetweenEnemiesSpawn,_decreaseStep);
        gameValuesChanger.TryDecreaseValue(ref _timeBetweenCoinsSpawn, _minTimeBetweenCoinsSpawn,_decreaseStep);
        gameValuesChanger.TryDecreaseValue(ref _timeBetweenLongObjectsSpawn, _minTimeBetweenLongObjectsSpawn,_decreaseStep);
        
    }

    private void SetObject(GameObject obj)
    {
        obj.SetActive(true);
        _randomPositionMover.MoveObjectToPosition(obj);
    }

    private void CheckPassedTime(float passedTime, float timeBetweenSpawn, string _objClass)
    {
        if (passedTime >= timeBetweenSpawn)
        {
            switch (_objClass)
            {
                case "enemy":
                    if (TryGetObject(out GameObject obj, _pool))
                    {
                        _passedTimeBetweenEnemiesObjects = 0;
                        SetObject(obj);
                    }
                    break;
                case "coin":
                    if (TryGetObject(out GameObject coin, _coinsPool))
                    {
                        _passedTimeBetweenCoinsObjects = 0;
                        SetObject(coin);
                    }
                    break;
                case "longObj":
                    if (TryGetObject(out GameObject longObj, _longObjPool))
                    {
                        _passedTimeBetweenLongObjects = 0;
                        SetObject(longObj);
                    }
                    break;
            }
        }
    }
}
 