using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] protected Transform _objectsContainer;
    [SerializeField] protected Transform _coinsContainer;
    [SerializeField] protected Transform _longObjContainer;
    
    [SerializeField] private int _amountOfObjects;

    System.Random random = new System.Random(); 

    protected List<GameObject> _pool = new List<GameObject>();
    
    protected List<GameObject> _coinsPool = new List<GameObject>();
    
    protected List<GameObject> _longObjPool = new List<GameObject>();

    protected void Initialize(GameObject objectPrefab)
    {
        for (int i = 0; i < _amountOfObjects; i++)
        {
            GameObject spawnedCoin = Instantiate(objectPrefab, _coinsContainer.transform);
            spawnedCoin.SetActive(false);

            _coinsPool.Add(spawnedCoin);
        }
    }

    protected void Initialize(GameObject[] objectPrefabs, List<GameObject> list, Transform listTransform)
    {
        for (int i = 0; i < _amountOfObjects; i++)
        {
            GameObject spawnedEnemy = Instantiate(objectPrefabs[random.Next(0,objectPrefabs.Length)], listTransform.transform);
            spawnedEnemy.SetActive(false);

            list.Add(spawnedEnemy);
        }
    }

    protected bool TryGetObject(out GameObject result, List<GameObject> list)
    {
        result = list.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }
}
