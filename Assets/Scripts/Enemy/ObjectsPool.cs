using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private Transform _enemiesContainer;
    [SerializeField] private int _amountOfEnemies;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject _enemyPrefab)
    {
        for (int i = 0; i < _amountOfEnemies; i++)
        {
            GameObject spawnedEnemy = Instantiate(_enemyPrefab, _enemiesContainer.transform);
            spawnedEnemy.SetActive(false);

            _pool.Add(spawnedEnemy);
        }
    }

    protected bool TryGetEnemy(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }
}
