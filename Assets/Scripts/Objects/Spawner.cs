using UnityEngine;

public class Spawner : ObjectsPool
{
    [SerializeField] private GameObject _objectPrefab;

    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private float _minTimeBetweenSpawn;
    [SerializeField] private float _decreaseStep;

    [SerializeField] private GameValuesChanger gameValuesChanger;

    private float _passedTimeBetweenObjects = 0;
    
    private RandomPositionMover _randomPositionMover;

    private void Start()
    {
        _randomPositionMover = gameObject.GetComponent<RandomPositionMover>();
        Initialize(_objectPrefab);
    }

    private void Update()
    {
        _passedTimeBetweenObjects += Time.deltaTime;

        if (_passedTimeBetweenObjects >= _timeBetweenSpawn)
        {
            if (TryGetObject(out GameObject obj))
            {
                _passedTimeBetweenObjects = 0;
                SetObject(obj);
            }
        }
        gameValuesChanger.TryDecreaseValue(ref _timeBetweenSpawn, _minTimeBetweenSpawn,_decreaseStep);
    }

    private void SetObject(GameObject obj)
    {
        obj.SetActive(true);
        _randomPositionMover.MoveToPosition(obj);
    }
}
 