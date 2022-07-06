using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private Animator _playerAnimator;

    private void Start()
    {
        _playerAnimator = GameObject.FindWithTag("MainPlayer").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
            Die();
            _playerAnimator.SetTrigger("Hit");
        }
    }
    private void Die()
    {
        gameObject.SetActive(false);
    }
}
