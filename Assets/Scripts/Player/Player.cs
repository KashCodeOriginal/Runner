using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _coins;
    
    private Animator _animator;

    public event UnityAction<int> PlayerHealthChanged;
    public event UnityAction<int> PlayerCoinsChanged;
    
    public event UnityAction Died;
    
    private void Start()
    {
        LoadCoins();
        PlayerHealthChanged?.Invoke(_health);
        PlayerCoinsChanged?.Invoke(_coins);
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
        _coins += ammount;
        
        PlayerCoinsChanged?.Invoke(_coins);

        SaveCoins();
    }

    private void Die()
    {
        _animator.SetBool("PlayerDied", true);
        Died?.Invoke();
    }
    
    private void SaveCoins()
    {
        PlayerPrefs.SetInt("coins",_coins);
    }
    private void LoadCoins()
    {
        _coins = PlayerPrefs.GetInt("coins");
    }
}
