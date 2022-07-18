using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Abilities : MonoBehaviour
{
    public event UnityAction<int> PlayerAddHealth;
    public event UnityAction<bool> PlayerDoubleCoins;
    public event UnityAction PlayerDoubleScore;
    
    public event UnityAction<bool> PlayerInvulnerability;
    
    [SerializeField] private List<GameObject> _abilities = new List<GameObject>();
    [SerializeField] private List<ShopItem> _shopItems = new List<ShopItem>();

    [SerializeField] private int _healthWithBonus;

    [SerializeField] private GameStarted _gameStarted;

    [SerializeField] private Player _player;
    public void OnGameStarted()
    {
        for (int i = 0; i < _abilities.Count; i++)
        {
            if (_shopItems[i]._amountOfItemPlayerHas > 0)
            {
                Instantiate(_abilities[i], new Vector3(0, 0, 0), Quaternion.identity, transform);
            }
        }
        StartCoroutine(WaitForDestroy());
    }

    public void AddHearts()
    {
        if (_shopItems[0]._amountOfItemPlayerHas > 0)
        {
            PlayerAddHealth?.Invoke(_healthWithBonus);
            _gameStarted.DisplayHearts();
            _shopItems[0]._amountOfItemPlayerHas--;
        }
    }
    public void DoubleCoins()
    {
        if (_shopItems[1]._amountOfItemPlayerHas > 0)
        {
            PlayerDoubleCoins?.Invoke(true);
            _shopItems[1]._amountOfItemPlayerHas--;
        }
    }
    public void DoubleScore()
    {
        if (_shopItems[2]._amountOfItemPlayerHas > 0)
        {
            PlayerDoubleScore?.Invoke();
            _shopItems[2]._amountOfItemPlayerHas--;
        }
    }
    public void Invulnerability()
    {
        if (_shopItems[3]._amountOfItemPlayerHas > 0)
        {
            PlayerInvulnerability?.Invoke(true);
            StartCoroutine(InbulnerabilityTimer());
            _shopItems[3]._amountOfItemPlayerHas--;
        }
    }
    public void DeleteAllEnemies()
    {
        if (_shopItems[4]._amountOfItemPlayerHas > 0)
        {
            _player.DeleteAllActiveEnemies();
            _shopItems[4]._amountOfItemPlayerHas--;
        }
    }

    private IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(10f);
    }

    private IEnumerator InbulnerabilityTimer()
    {
        yield return new WaitForSeconds(30f);
        PlayerInvulnerability?.Invoke(false);
    }
}
