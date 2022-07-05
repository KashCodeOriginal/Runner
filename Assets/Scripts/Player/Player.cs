using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private Animator _animator;

    public event UnityAction<int> PlayerHealthChanged;
    public event UnityAction Died;
    
    private void Start()
    {
        PlayerHealthChanged?.Invoke(_health);
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

    private void Die()
    {
        _animator.SetBool("PlayerDied", true);
        Died?.Invoke();
    }
}
