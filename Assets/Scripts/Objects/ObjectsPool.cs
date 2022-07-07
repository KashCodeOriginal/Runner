using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private Transform _objectsContainer;
    [SerializeField] private Transform _coinsContainer;
    [SerializeField] private int _amountOfObjects;
    
    System.Random random = new System.Random();

    private List<GameObject> _pool = new List<GameObject>();
    
    private List<GameObject> _coinsPool = new List<GameObject>();

    protected void Initialize(GameObject _objectPrefab)
    {
        for (int i = 0; i < _amountOfObjects; i++)
        {
            GameObject spawnedCoin = Instantiate(_objectPrefab, _coinsContainer.transform);
            spawnedCoin.SetActive(false);

            _coinsPool.Add(spawnedCoin);
        }
    }
    protected void Initialize(GameObject[] _objectPrefabs)
    {
        for (int i = 0; i < _amountOfObjects; i++)
        {
            GameObject spawnedEnemy = Instantiate(_objectPrefabs[random.Next(0,_objectPrefabs.Length)], _objectsContainer.transform);
            spawnedEnemy.SetActive(false);

            _pool.Add(spawnedEnemy);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }
    protected bool TryGetCoinObject(out GameObject result)
    {
        result = _coinsPool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }
}
