using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _totalCoins;
    [SerializeField] private int _currentCoins;

    [SerializeField] private Sounds _sounds;

    [SerializeField] private ParticleSystem _particleSystem;

    [SerializeField] private TMP_Text _totalCoinsValue;

    [SerializeField] private Shop _shop;

    [SerializeField] private Abilities _abilities;
    
    private Animator _animator;
    
    public event UnityAction<int> PlayerHealthChanged;
    public event UnityAction<int> PlayerCoinsChanged;

    public event UnityAction PlayerCanBuyItem;
    
    public event UnityAction Died;
    
    private void Start()
    {
        Application.targetFrameRate = 60;
        LoadCoins();
        PlayerHealthChanged?.Invoke(_health);
        _currentCoins = 0;
        PlayerCoinsChanged?.Invoke(_currentCoins);
        _animator = gameObject.GetComponent<Animator>();

        _totalCoinsValue.text = _totalCoins.ToString();
    }
    
    public void ApplyDamage(int damage)
    {
        _health -= damage;
        
        PlayerHealthChanged?.Invoke(_health);
        
        if (_health <= 0)
        {
            Die();
        }
        
        _sounds.PlayHitSound();
        _particleSystem.Play();
    }

    public void AddCoin(int ammount)
    {
        _currentCoins += ammount;
        _totalCoins += ammount;
        
        PlayerCoinsChanged?.Invoke(_currentCoins);

        SaveCoins();
        
        _sounds.PlayCoinCollectSound();
    }

    private void Die()
    {
        _animator.SetBool("PlayerDied", true);
        Died?.Invoke();
    }
    
    private void SaveCoins()
    {
        PlayerPrefs.SetInt("coins",_totalCoins);
    }
    private void LoadCoins()
    {
        _totalCoins = PlayerPrefs.GetInt("coins");
    }

    private void OnEnable()
    {
        _shop.PlayerTryToByItem += TryBuyItem;
        _abilities.PlayerAddHealth += AddHealth;
    }
    private void OnDisable()
    {
        _shop.PlayerTryToByItem -= TryBuyItem;
        _abilities.PlayerAddHealth -= AddHealth;
    }

    private void TryBuyItem(int itemCost)
    {
        if (_totalCoins >= itemCost)
        {
            PlayerCanBuyItem?.Invoke();
            _totalCoins -= itemCost;
            _totalCoinsValue.text = _totalCoins.ToString();
        }
        else
        {
            _sounds.PlayUnSuccessfulBuySound();
        }
    }

    private void AddHealth(int health)
    {
        _health = health;
        PlayerHealthChanged?.Invoke(_health);
    }
}
