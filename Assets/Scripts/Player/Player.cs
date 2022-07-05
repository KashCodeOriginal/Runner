using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction<int> PlayerHealthChanged;

    private void Start()
    {
        PlayerHealthChanged?.Invoke(_health);
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

    private void Die()
    {
        Destroy(gameObject);
    }
}
