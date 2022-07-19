using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [SerializeField] private TMP_Text _abilityText;

    [SerializeField] private Sounds _sounds;
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
        PlayerAddHealth?.Invoke(_healthWithBonus);
        _gameStarted.DisplayHearts();
        _shopItems[0]._amountOfItemPlayerHas--;
        AddAbilityText(0);
        _sounds.PlayAbilitiesSound();
    }
    public void DoubleCoins()
    {
        PlayerDoubleCoins?.Invoke(true);
        _shopItems[1]._amountOfItemPlayerHas--;
        AddAbilityText(1);
        _sounds.PlayAbilitiesSound();
    }
    public void DoubleScore()
    {
        PlayerDoubleScore?.Invoke();
        _shopItems[2]._amountOfItemPlayerHas--;
        AddAbilityText(2);
        _sounds.PlayAbilitiesSound();
    }
    public void Invulnerability()
    {
        if (_shopItems[3]._amountOfItemPlayerHas > 0)
        {
            PlayerInvulnerability?.Invoke(true);
            StartCoroutine(InbulnerabilityTimer());
            _shopItems[3]._amountOfItemPlayerHas--;
            AddAbilityText(3);
            _sounds.PlayAbilitiesSound();
        }
    }
    public void DeleteAllEnemies()
    {
        if (_shopItems[4]._amountOfItemPlayerHas > 0)
        {
            _player.DeleteAllActiveEnemies();
            _shopItems[4]._amountOfItemPlayerHas--;
            AddAbilityText(4);
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

    private void AddAbilityText(int i)
    {
        _abilityText.gameObject.GetComponent<Animation>().Stop();
        _abilityText.text = _shopItems[i]._name + " Is Activated";
        _abilityText.gameObject.GetComponent<Animation>().Play("AbilityText");
    }
}
