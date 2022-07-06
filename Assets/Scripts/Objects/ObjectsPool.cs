using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private Transform _objectsContainer;
    [SerializeField] private int _amountOfObjects;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject _objectPrefab)
    {
        for (int i = 0; i < _amountOfObjects; i++)
        {
            GameObject spawnedEnemy = Instantiate(_objectPrefab, _objectsContainer.transform);
            spawnedEnemy.SetActive(false);

            _pool.Add(spawnedEnemy);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }
}
