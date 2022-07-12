using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _totalCoins;
    [SerializeField] private int _currentCoins;
    
    private Animator _animator;

    public event UnityAction<int> PlayerHealthChanged;
    public event UnityAction<int> PlayerCoinsChanged;
    
    public event UnityAction Died;
    
    private void Start()
    {
        LoadCoins();
        PlayerHealthChanged?.Invoke(_health);
        _currentCoins = 0;
        PlayerCoinsChanged?.Invoke(_currentCoins);
        _animator = gameObject.GetComponent<Animator>();
    }
    
    public void ApplyDamage(int damage)
    {
        _health -= damage;
        
        PlayerHealthChanged?.Invoke(_health);
        
        if (_health <= 0)
        {
            Die();
        }
    }

    public void AddCoin(int ammount)
    {
        _currentCoins += ammount;
        _totalCoins += ammount;
        
        PlayerCoinsChanged?.Invoke(_currentCoins);

        SaveCoins();
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
}
