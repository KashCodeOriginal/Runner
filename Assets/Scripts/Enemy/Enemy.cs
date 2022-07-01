using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
