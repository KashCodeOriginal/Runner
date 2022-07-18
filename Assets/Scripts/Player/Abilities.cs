using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Abilities : MonoBehaviour
{
    [SerializeField] private List<GameObject> _abilities = new List<GameObject>();
    [SerializeField] private List<ShopItem> _shopItems = new List<ShopItem>();

    [SerializeField] private int _healthWithBonus;

    [SerializeField] private GameStarted _gameStarted;
    
    public event UnityAction<int> PlayerAddHealth;
    public void OnGameStarted()
    {
        for (int i = 0; i < _abilities.Count; i++)
        {
            if (_shopItems[i]._amountOfItemPlayerHas > 0)
            {
                Instantiate(_abilities[i], new Vector3(0, 0, 0), Quaternion.identity, transform);
            }
        }
    }

    public void AddHearts()
    {
        PlayerAddHealth?.Invoke(_healthWithBonus);
        _gameStarted.DisplayHearts();
    }
    public void DoubleCoins()
    {
        
    }
    public void DoubleScore()
    {
        
    }
    public void Invulnerability()
    {
        
    }
    public void DeleteAllEnemies()
    {
        
    }
    
}
